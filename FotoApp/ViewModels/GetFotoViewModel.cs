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
        public IViewModel SelectPaperPanel { get; set; }
        
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

        public bool CanOk => _type != null &&  activOkButton == true;

        #endregion

        #region Constractor

        public GetFotoViewModel(SchellViewModel schell, IEventAggregator eventAggregator)
        {
            this.schell = schell;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
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
            MainPanel = new ListFotoViewModel(this, EventAggregator);
            SelectPaperPanel = new ChangePapersAndSiseViewModel(this, EventAggregator);
            _closingOrder = false;
            NotifyMainPanel();
            NotifySelectPaperPanel();
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
                NotifyMainPanel();
            }
            else
            {
                _closingOrder = false;
                activOkButton = false;
                FinalColectionDelegat?.Invoke();
                EventAggregator.PublishOnCurrentThread(FotoCollection);
                MainPanel = null;
                NotifyMainPanel();
                NotifyCanOk();
            }
        }
        private void NotifyMainPanel()
        {
            NotifyOfPropertyChange(() => MainPanel);
        }
        private void NotifySelectPaperPanel()
        {
            NotifyOfPropertyChange(() => SelectPaperPanel);
        }
        private void NotifyCanOk()
        {
            NotifyOfPropertyChange(() => CanOk);
        }
        public void Handle(IEnumerable<object> message)
        {
            var list = message.ToList();
            if (true)
            {
                _type = (int)list[0];
            }
            NotifyOfPropertyChange(() => CanOk);
        }

        public void Handle(bool message)
        {
            activOkButton = message;
            NotifyOfPropertyChange(() => CanOk);
        }
        #endregion
    }
}
