using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Schell;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel : Screen, IViewModelEventAggregator, IViewModel, IHandle<IEnumerable<object>>,  IHandle<bool>
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }
        public IViewModel ChangePapersAndSise { get; set; }

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
        private bool? activ;
        private SchellViewModel schell;

        public FinalFotoColection FotoCollection
        {
            get => _finalFotoColection;
            set
            {
                _finalFotoColection = value;
                NotifyOfPropertyChange(() => FotoCollection);
                NotifyOfPropertyChange(() => CanCd);
            }
        }

        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        public string Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                NotifyOfPropertyChange(() => Discount);
            }
        }

        public int Count
        {
            get => _count;
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

        public bool CanOk => _type != null && _sise != null && activ == true;

        #endregion

        #region Constractor

        public GetFotoViewModel(SchellViewModel schell, IEventAggregator eventAggregator)
        {
            this.schell = schell;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
            ChangePapersAndSise = new ChangePapersAndSiseViewModel(EventAggregator);
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
                MainPanel = new ClosingOrderViewModel(this);
                NotifyOfPropertyChange(() => MainPanel);
            }
            else
            {
                _closingOrder = false;
                FinalColectionDelegat?.Invoke();
                MainPanel = null;
                NotifyOfPropertyChange(() => MainPanel);
                EventAggregator.PublishOnCurrentThread(FotoCollection);
            }
        }

        #endregion

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
            yield return (int)_type;
            yield return _sise;
        }

        public void Handle(bool message)
        {
            activ = message;
            NotifyOfPropertyChange(() => CanOk);
        }
    }
}
