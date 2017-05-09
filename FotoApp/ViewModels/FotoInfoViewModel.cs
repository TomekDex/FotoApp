using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Helpers;
using FotoAppDB.DBModel;
using Types = FotoApp.Models.ChangePapersAnSiseModel.Types;

namespace FotoApp.ViewModels
{
    public sealed class FotoInfoViewModel :ViewModelBase.ViewModelBase, IHandle<BitmapImage>, IHandle<Fotos>, IHandle<Papers>, IHandle<OrderFoto>
    {
        public delegate void ChangeOrder();
        public event ChangeOrder changeOrder;

        #region Proportis
        private const int MinCount = 1;
        private int _countFoto;
        private BindableCollection<SizeM> _siseList;
        private BindableCollection<Types> _typeList;
        private BitmapImage _image;
        private GetPapers _papers;
        private Fotos _Foto;
        private Papers _defPaper;
        private Papers _paper;
        private OrderFoto _orderFoto;
        private bool change = true;
        private bool changePaper = true;
        private bool changeCountFoto;

        public BindableCollection<SizeM> SizeList
        {
            get { return _siseList; }
            set
            {
                _siseList = value;
                NotifyOfPropertyChange(() => SizeList);
            }
        }

        public BindableCollection<Types> TypeList
        {
            get { return _typeList; }
            set
            {
                _typeList = value;
                NotifyOfPropertyChange(() => TypeList);
            }
        }
        public int CountFoto
        {
            get => _countFoto;
            set
            {
                if (_countFoto <= MinCount)
                    return;
                _countFoto = value;
                NotifyOfPropertyChange(() => CountFoto);
            }
        }
        public BitmapImage Image
        {
            get => _image;
            set
            {
                _image = value;
                _countFoto = MinCount;
                NotifyOfPropertyChange(()=> CountFoto);
                NotifyOfPropertyChange(() => Image);
            }
        }

        #endregion

        #region Constractor

        public FotoInfoViewModel(GetFotoViewModel _getFoto) : base(_getFoto)
        {
            _papers = new GetPapers();
            TypeList = _papers.GetTypes();
            SizeList = _papers.GetSizesByType(_papers.GetTypeByIndex(1));
            EventAggregator.Subscribe(this);
        }

        #endregion

        public bool CanOk => ((change && changePaper && changeCountFoto) ||( changeCountFoto && changePaper));
        #region Acrion

        public void Add()
        {
            _countFoto++;
            changeCountFoto = true;
            NotifyOfPropertyChange(() => CountFoto);
            NotifyOfPropertyChange(() => CanOk);
        }

        public void Sub()
        {
            if (_countFoto <=1) return;
            _countFoto--;
            changeCountFoto = true;
            NotifyOfPropertyChange(() => CountFoto);
            NotifyOfPropertyChange(() => CanOk);
        }

        public void Ok()
        {
            if (change)
            {
                var tmp = !changePaper || changeCountFoto ? _defPaper:  _paper;
                var l = new OrderFotoHelper(_Foto, _defPaper, _countFoto);
                l.ChangeOrderFoto(tmp, _countFoto);
                var ofd = new OrderFotoDisplayHelper();
                ofd.ModifOrderFoto(_orderFoto, tmp, CountFoto);
                change = false;
                changePaper = false;
                CountFoto = MinCount;
                NotifyOfPropertyChange(() => CanOk);
                OnChangeOrder();
            }
            else
            {
                var l = new OrderFotoHelper(_Foto, _paper, _countFoto);
                l.AddOrderFoto();
                var ofd = new OrderFotoDisplayHelper(_paper, Image, _Foto, _countFoto);
                ofd.Publish();
                changePaper = false;
                CountFoto = MinCount;
                NotifyOfPropertyChange(() => CanOk);
                OnChangeOrder();

            }
        }
        public void ChangeType(object o)
        {
            _siseList = new BindableCollection<SizeM>();
            _paper = new Papers();
            var tmp = o as Types;
            if (tmp != null)
            {
                SizeList = _papers.GetSizesByType(_papers.GetTypeByIndex(tmp.id));
            }
            NotifyOfPropertyChange(() => SizeList);

            _paper.TypeID = tmp.id;
            changePaper = false;
            NotifyOfPropertyChange(() => CanOk);
        }

        public void ChangeSize(object o)
        {
            var tmp = o as SizeM;
            _paper.Height = tmp.Height;
            _paper.Width = tmp.Width;
            changeCountFoto = true;
            changePaper = true;
            NotifyOfPropertyChange(() => CanOk);
        }

        public void Handle(Papers message)
        {
            _defPaper = message;
        }

        public void Handle(BitmapImage message)
        {
            Image = message;
            NotifyOfPropertyChange(()=> Image);
        }

        public void Handle(Fotos message)
        {
            _countFoto = MinCount;
            change = false;
            _Foto = message;
            NotifyOfPropertyChange(() => CountFoto);
            NotifyOfPropertyChange(() => CanOk);
        }

        public void Handle(OrderFoto message)
        {
            _orderFoto = message;
        }

        private void OnChangeOrder()
        {
            changeOrder?.Invoke();
        }
    }
    #endregion
}
