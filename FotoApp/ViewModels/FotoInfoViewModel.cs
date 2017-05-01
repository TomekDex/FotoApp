using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Helpers;
using FotoAppDB.DBModel;
using Types = FotoApp.Models.ChangePapersAnSiseModel.Types;

namespace FotoApp.ViewModels
{
    public class FotoInfoViewModel :ViewModelBase.ViewModelBase, IHandle<BitmapImage>, IHandle<Fotos>, IHandle<Papers>, IHandle<OrderFoto>
    {
        #region Proportis
        //public ChangePapersAndSiseViewModel PaperPanel { get; set; }
        private const int MinCount = 1;
        private int _countFoto;
        private BindableCollection<SizeM> _siseList;
        private BindableCollection<Types> _TypeList;
        private BitmapImage _image;
        private GetPapers _papers;
        private Fotos _Foto;
        private Papers _paper;
        private OrderFoto _orderFoto;
        private bool change = true;
       
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

        public FotoInfoViewModel(GetFotoViewModel _getFoto) : base(_getFoto)
        {
            _papers = new GetPapers();
            EventAggregator.Subscribe(this);
            /*PaperPanel = new ChangePapersAndSiseViewModel(_getFoto);
            NotifyOfPropertyChange(()=> PaperPanel);*/
        }

        #region Acrion

        public void Add()
        {
            _countFoto++;
            NotifyOfPropertyChange(() => CountFoto);
        }

        public void Sub()
        {
            _countFoto--;
            NotifyOfPropertyChange(() => CountFoto);
        }

        public void Ok()
        {
            if (change)
            {
                var l = new OrderFotoHelper(_Foto, _paper, _countFoto);
                l.ChangeOrderFoto(_paper, _countFoto);
                var ofd = new OrderFotoDisplayHelper();
                ofd.ModifOrderFoto(_orderFoto, _paper, CountFoto);
                change = false;
            }
            else
            {
                var l = new OrderFotoHelper(_Foto, _paper, _countFoto);
                l.AddOrderFoto();
                var ofd = new OrderFotoDisplayHelper(_paper, Image, _countFoto);
                ofd.Publish();
            }
        }
        public void Handle(Papers message)
        {
            _paper = message;
        }

        public void Handle(BitmapImage message)
        {
            Image = message;
            NotifyOfPropertyChange(()=> Image);
        }

        public void Handle(Fotos message)
        {
            _countFoto = MinCount;
            _Foto = message;
            NotifyOfPropertyChange(() => CountFoto);
        }

        public void Handle(OrderFoto message)
        {
            _orderFoto = message;
        }
    }
    #endregion
}
