using System.Collections.Generic;
using System.IO;
using Caliburn.Micro;
using FotoApp.Extension;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Helpers;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels
{
    public sealed class ListFotoViewModel : ViewModelBase.ViewModelBase, IHandle<DriveInfo>, IHandle<Papers>
    {

        private readonly GetFotoViewModel _getFoto;
        public delegate void ActivCheckBox();
        public delegate void ChangeOrder();

        public event ChangeOrder changeOrder;
        public event ActivCheckBox activCheckBox;

        #region Propertis;

        private BindableCollection<Foto> _curentPage;
        private BindableCollection<Foto> _beforePage;
        private BindableCollection<Foto> _afterPage;

        private List<string> _listFoto;
        private Papers _paper;
        private int _page = 1;
        private int _countPage;
        private string _total;
        private string _occupied;

        public string Total
        {
            get => _total;
            set
            {
                _total = value;
                NotifyOfPropertyChange(()=> Total);
            }
        }
        public string Occupied
        {
            get => _occupied;
            set
            {
                _occupied = value;
                NotifyOfPropertyChange(()=> Occupied);
            }
        }
        public BindableCollection<Foto> CurentPage 
        {
            get => _curentPage;
            set
            {
                _curentPage = value;
                NotifyOfPropertyChange(() => CurentPage);
            }
        }
        public int Page
        {
            get => _page;
            set
            {
                if (value <= 1)
                {
                    _page = 1;
                }
                else if (value > _countPage)
                {
                    _page = _countPage;
                }
                else
                {
                    _page = value;
                }
                NotifyOfPropertyChange(()=> Page);
            }
        }
        public int CountPage
        {
            get => _countPage;
            set
            {
                _countPage = value; 
                NotifyOfPropertyChange(()=>CountPage);
            }
        }
        #endregion

        #region Constractor
        public ListFotoViewModel(GetFotoViewModel getFoto)
            : base(getFoto)
        {
            var newOrder = NewOrder.New_Order;
            newOrder.CreateDirectory(Pref.Preference.DefaultPath);
            _getFoto = getFoto;
            EventAggregator.Subscribe(this);
        }

        #endregion

        #region Action

        public void Up()
        {
            _page++;
            _beforePage = _curentPage;
            _curentPage = _afterPage;
            NotifyOfPropertyChange((() => CurentPage));
            var l = new LoadFotoHelper(null);
            _afterPage = l.LoadPageFoto(_page + 1, _listFoto);
        }

        public void Down()
        {
            _page--;
            _afterPage = _curentPage;
            _curentPage = _beforePage;
            NotifyOfPropertyChange((() => CurentPage));
            var l = new LoadFotoHelper(null);
            _afterPage = l.LoadPageFoto(_page - 1, _listFoto);
        }

       

        public void ActiveChechBox(object itemBox)
        {
            OnActivCheckBox();
            var tmp = itemBox as Foto;
            var path = tmp.path;
            var fileName = Path.GetFileName(path);
            var foto = new FotosHelper(fileName);
            foto.AddFoto();
            if (_paper == null)
            {
                _paper = GetPapers.GetDefaultPaper();
            }
            var orederFoto = new OrderFotoHelper(foto.Foto, _paper, 1);
            orederFoto.AddOrderFoto();
            var ord = new OrderFotoDisplayHelper(_paper, tmp.bitmap, foto.Foto, 1);
            ord.Publish();
            EventPublish(tmp, foto);
            var copyFoto = CopyFotoHelper.CopyFoto;
            copyFoto.Add(path);
            OnChangeOrder();
        }

        private void EventPublish(Foto tmp, FotosHelper foto)
        {
            EventAggregator.PublishOnCurrentThread(true);
            EventAggregator.PublishOnCurrentThread(tmp.bitmap);
            EventAggregator.PublishOnCurrentThread(foto.Foto);
            EventAggregator.PublishOnCurrentThread(_paper);
            EventAggregator.Unsubscribe(this);
        }

        public void Handle(DriveInfo message)
        {
            _curentPage = new BindableCollection<Foto>();
            var l = new LoadFotoHelper(message.Name);
            _total = message.TotalSize.ByteToMbFotmat();
            _occupied = message.AvailableFreeSpace.ByteToMbFotmat();
            _listFoto = l.ActivLoadFoto();
            _countPage = _listFoto.Count / 12 + 1;
            _curentPage = l.LoadPageFoto(1, _listFoto);
            _afterPage = l.LoadPageFoto(2, _listFoto);
            NotifyOfPropertyChange(() => CurentPage);
        }
        public void Handle(Papers message)
        {
            _paper = message;
        }

        private void OnActivCheckBox()
        {
            activCheckBox?.Invoke();
        }

        private void OnChangeOrder()
        {
            changeOrder?.Invoke();
        }
        #endregion
    }
}
