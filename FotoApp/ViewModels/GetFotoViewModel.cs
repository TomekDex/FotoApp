using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Schell;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel :Conductor<object>, ISchellable
    {
        public SchellViewModel Schell { get; set; }

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
        public GetFotoViewModel(SchellViewModel schell)
        {
            Schell = schell;
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
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Usb2()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Cd()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Cart()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
            _closingOrder = false;
        }
        public void Ok()
        {
            if (!_closingOrder)
            {
                _closingOrder = true;
                FinalColectionDelegat();
                ActivateItem(new ClosingOrderViewModel(Schell, this));
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
