using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Models.FotoColection;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel : Screen, IViewModelEventAggregator, IViewModel, IHandle<IEnumerable<object>>,  IHandle<bool>
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }
        public IViewModel ChangePapersAndSise { get; set; }
        private ListFotoViewModel List;
        
        #region Delegate

        public delegate void FinalColectionDelegate();

        public event FinalColectionDelegate FinalColectionDelegat;

        #endregion

        #region  Propertis

        private string _price;
        private string _discount;
        private int _count = 12;
        private bool _closingOrder;
        private FinalFotoColection _finalFotoColection;
        private int? _type;
        private Sizes _sise;
        private bool? activOkButton;
        private SchellViewModel schell;

        public FinalFotoColection FotoCollection
        {
            get { return _finalFotoColection; }
            set
            {
                _finalFotoColection = value;
                NotifyOfPropertyChange(() => FotoCollection);
                NotifyOfPropertyChange(() => CanCd);
            }
        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        public string Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
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

        public bool CanUsb1 => true;

        public bool CanUsb2 => true;

        public bool CanCd => true;

        public bool CanCart => true;

        public bool CanOk => _type != null && _sise != null && activOkButton == true;

        #endregion

        #region Constractor

        public GetFotoViewModel(SchellViewModel schell, IEventAggregator eventAggregator)
        {
            this.schell = schell;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
            List = new ListFotoViewModel(this, eventAggregator);
            ChangePapersAndSise = new ChangePapersAndSiseViewModel(this, EventAggregator, List);
            FotoCollection = new FinalFotoColection();
            _type = null;
#if DEBUG
            _discount = "kjsdhsdkjfhsdkfs";
            _price = "klsdfjskdfhsdf";
#endif
        }

        #endregion

        #region  Actions

        public void Usb1()
        {
            MainPanel = List;
            _closingOrder = false;
            EventAggregator.PublishOnCurrentThread(GetTypes());
            NotifyOfPropertyChange(() => MainPanel);
        }

        public void Usb2()
        {
            MainPanel = new ListFotoViewModel(this, EventAggregator);
            _closingOrder = false;
        }

        public void Cd()
        {
            MainPanel = new ListFotoViewModel(this, EventAggregator);
            _closingOrder = false;
        }

        public void Cart()
        {
            MainPanel = new ListFotoViewModel(this, EventAggregator);
            _closingOrder = false;
        }

        public void Ok()
        {
            if (!_closingOrder)
            {
                _closingOrder = true;
                FinalColectionDelegat?.Invoke();
                MainPanel = new ClosingOrderViewModel(this, EventAggregator);
                NotifyOfPropertyChange(() => MainPanel);
            }
            else
            {
                _closingOrder = false;
                activOkButton = false;
                FinalColectionDelegat?.Invoke();
                NotifyOfPropertyChange(() => MainPanel);
                NotifyOfPropertyChange(() => CanOk);
                EventAggregator.PublishOnCurrentThread(FotoCollection);
                MainPanel = null;
            }
        }
        public void Handle(IEnumerable<object> message)
        {
            var list = message.ToList();
            if (true)
            {
                _type = (int)list[0];
                _sise = list[1] as Sizes;
            }
            NotifyOfPropertyChange(() => CanOk);
        }

        private IEnumerable<object> GetTypes()
        {
            if (_type != null) yield return (int)_type;
            yield return _sise;
        }

        public void Handle(bool message)
        {
            activOkButton = message;
            NotifyOfPropertyChange(() => CanOk);
        }
        #endregion
    }
}
