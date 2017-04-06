using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel :Conductor<object>, ISchellable
    {
        public SchellViewModel Schell { get; set; }

        #region Delegate

        public delegate FinalColection FinalColectionDelegate();
        public delegate string ChangeName();
        public delegate string ChangePhone();
        public delegate string ChangeMail();

        public event FinalColectionDelegate FinalColectionDelegat = null;
        public event ChangeMail ChangeMailDelegate = null;
        public event ChangeName ChangeNameDelegate = null;
        public event ChangePhone ChangePhoneDelegate = null;

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
                ActivateItem(new ClosingOrderViewModel(Schell, this));
                FotoCollection = FinalColectionDelegat();
                _closingOrder = true;
            }
            else
            {  // wczytanie danych z do zatwierdzenia zlecenia 

                FotoCollection.CustomerName = ChangeNameDelegate();
                FotoCollection.CustomerMail = ChangeMailDelegate();
                FotoCollection.CustomerPhoneNumber = ChangePhoneDelegate();
                _closingOrder = false;
                // przesłanie zamuwieniea do bazy danych
                ActivateItem(null);
            }
        }
        #endregion

    }
}
