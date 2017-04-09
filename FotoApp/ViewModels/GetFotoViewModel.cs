using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Schell;
using FotoApp.ViewModels.EvenArgs;
using FotoAppDBTest;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel :Conductor<object>, IViewModelEventAggregator, IViewModel
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }
        public IViewModel ChangePapersAndSise { get; set; }

        #region Delegate

        public delegate void FinalColectionDelegate();
        
        public event FinalColectionDelegate FinalColectionDelegat = null;
        
        #endregion

        #region  Propertis

        private string _price;
        private string _discount;
        private int _count = 12;
        private bool _closingOrder;
        private FinalColection _finalColection;
        public FinalColection FotoCollection
        {
            get { return _finalColection; }
            set
            {
                _finalColection = value;
                NotifyOfPropertyChange(() => FotoCollection);
                NotifyOfPropertyChange(()=> CanCd);
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price =  value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public string Discount
        {
            get { return _discount; }
            set
            {
                _discount =  value;
                NotifyOfPropertyChange(() => Discount);
            }
        }
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }
        #endregion

        #region CanProportis
        public bool CanUsb1
        {
            get
            {
                return true;
            }
        }
        public bool CanUsb2
        {
            get
            {
                return true;
            }
        }
        public bool CanCd
        {
            get
            {
                return true;
            }
        }
        public bool CanCart
        {
            get
            {
                return true;
            }
        }

        public bool CanOk
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Constractor
        public GetFotoViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            FotoCollection = new FinalColection();

#if DEBUG
            _discount = "kjsdhsdkjfhsdkfs";
            _price = "klsdfjskdfhsdf";
#endif
        }
        #endregion

        #region  Actions
        public void Usb1()
        {
            
            MainPanel = new ListFotoViewModel(EventAggregator);
            _closingOrder = false;
        }
        public void Usb2()
        {
            MainPanel = new ListFotoViewModel(EventAggregator);
            _closingOrder = false;
        }
        public void Cd()
        {
            MainPanel = new ListFotoViewModel(EventAggregator);
            _closingOrder = false;
        }
        public void Cart()
        {
            MainPanel = new ListFotoViewModel(EventAggregator);
            _closingOrder = false;
        }
        public void Ok()
        {
            if (!_closingOrder)
            {
                _closingOrder = true;
                FinalColectionDelegat();
                MainPanel = new ClosingOrderViewModel(EventAggregator);
            }
            else
            {  
                _closingOrder = false;
                FinalColectionDelegat();
                ActivateItem(null);
            }
        }
        #endregion

    }
}
