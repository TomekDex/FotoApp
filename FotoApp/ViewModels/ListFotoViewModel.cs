using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Helpers;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel : ViewModelBase.ViewModelBase, IHandle<DriveInfo>, IHandle<Papers>
    {

        private readonly GetFotoViewModel _getFoto;
        public delegate void GetPaperDelegate();
        public delegate void ActivCheckBox();
        public event ActivCheckBox activCheckBox;
        public event GetPaperDelegate getPaperDelegete;

        #region Propertis;

        private BindableCollection<Foto> _curentPage;
        private BindableCollection<Foto> _beforePage;
        private BindableCollection<Foto> _afterPage;

        private List<string> _listFoto;
        private Papers _paper;
        private int _page = 1;
        private int _countPage;
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
                else if (value > CountPage)
                {
                    _page = CountPage;
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
            getPaperDelegete?.Invoke();
        }

        #endregion

        #region Action

        public void Up()
        {
            Page++;
            _beforePage = _curentPage;
            _curentPage = _afterPage;
            NotifyOfPropertyChange((() => CurentPage));
            var l = new LoadFotoHelper(null);
            _afterPage = l.LoadPageFoto(Page + 1, _listFoto);
        }

        public void Down()
        {
            Page--;
            _afterPage = _curentPage;
            _curentPage = _beforePage;
            NotifyOfPropertyChange((() => CurentPage));
            var l = new LoadFotoHelper(null);
            _afterPage = l.LoadPageFoto(Page - 1, _listFoto);
        }

       

        public void ActiveChechBox(object itemBox)
        {
            activCheckBox?.Invoke();
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
            var ord = new OrderFotoDisplayHelper(_paper,tmp.bitmap, foto.Foto,1);
            ord.Publish();
            EventAggregator.PublishOnCurrentThread(true);
            EventAggregator.PublishOnCurrentThread(tmp.bitmap);
            EventAggregator.PublishOnCurrentThread(foto.Foto);
            EventAggregator.PublishOnCurrentThread(_paper);
            EventAggregator.Unsubscribe(this);
            var copyFoto = CopyFotoHelper.CopyFoto;
            copyFoto.Add(path);
        }
        public void Handle(DriveInfo message)
        {
            
            CurentPage = new BindableCollection<Foto>();
            var l = new LoadFotoHelper(message.Name);
            _listFoto = l.ActivLoadFoto();
            CountPage = _listFoto.Count / 12 + 1;
            _curentPage = l.LoadPageFoto(1, _listFoto);
            NotifyOfPropertyChange(() => CurentPage);
            _afterPage = l.LoadPageFoto(2, _listFoto);
        }
       #endregion

        public void Handle(Papers message)
        {
            _paper = message;
        }
    }
}
