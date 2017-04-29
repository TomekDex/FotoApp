using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.FotoColection;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel : Screen, IViewModelEventAggregator, IViewModel, IHandle<IEnumerable<object>>,  IHandle<bool>
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }
        public IViewModel SelectPaperPanel { get; set; }

        private string _pathUsb1 = @"e:\";
        private string _pathUsb2;
        private string _pathCd;
        private string _pathMemmory = @"d:\";


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
        private bool? _activOkButton;
        private bool? _activUsb1;
        private bool? _activUsb2;
        private bool? _activCd;
        private bool? _activMemmoryCard;
        private SchellViewModel schell;

        public FinalFotoColection FotoCollection
        {
            get { return _finalFotoColection; }
            set
            {
                _finalFotoColection = value;
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

        public bool CanUsb1 => _activUsb1 == true;

        public bool CanUsb2 => _activUsb1 == true;

        public bool CanCd => _activCd == true;

        public bool CanCart => _activMemmoryCard == true;

        public bool CanOk => _type != null &&  _activOkButton == true;

        #endregion

        #region Constractor

        public GetFotoViewModel(SchellViewModel schell, IEventAggregator eventAggregator)
        {
            this.schell = schell;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
            FotoCollection = new FinalFotoColection();
            EventAggregator.PublishOnCurrentThread(_pathUsb1);
            _type = null;
            ActivWmiEvent();
#if DEBUG
            _discount = "kjsdhsdkjfhsdkfs";
            _price = "klsdfjskdfhsdf";
#endif
        }

        #endregion

        #region  Actions

        public void Usb1()
        {
            if (null == MainPanel)
                MainPanel = new ListFotoViewModel(this, EventAggregator);
            NotifyMainPanel();

            if (null == SelectPaperPanel)
                SelectPaperPanel = new ChangePapersAndSiseViewModel(this, EventAggregator);
            Thread.Sleep(5000);
            _closingOrder = false;
            NotifySelectPaperPanel();
            EventAggregator.PublishOnCurrentThread(_pathUsb1);
        }

        public void Usb2()
        {
            if (null == MainPanel)
                MainPanel = new ListFotoViewModel(this, EventAggregator);
            if (null == SelectPaperPanel)
                SelectPaperPanel = new ChangePapersAndSiseViewModel(this, EventAggregator);
            _closingOrder = false;
            NotifyMainPanel();
            NotifySelectPaperPanel();
            EventAggregator.PublishOnCurrentThread(_pathUsb2);
        }

        public void Cd()
        {
            if (null == MainPanel)
                MainPanel = new ListFotoViewModel(this, EventAggregator);
            if (null == SelectPaperPanel)
                SelectPaperPanel = new ChangePapersAndSiseViewModel(this, EventAggregator);
            _closingOrder = false;
            NotifyMainPanel();
            NotifySelectPaperPanel();
            EventAggregator.PublishOnCurrentThread(_pathCd);
        }

        public void Cart()
        {
            if (null == MainPanel)
                MainPanel = new ListFotoViewModel(this, EventAggregator);
            if (null == SelectPaperPanel)
                SelectPaperPanel = new ChangePapersAndSiseViewModel(this, EventAggregator);
            _closingOrder = false;
            NotifyMainPanel();
            NotifySelectPaperPanel();
            EventAggregator.PublishOnCurrentThread(_pathMemmory);
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
                _activOkButton = false;
                FinalColectionDelegat?.Invoke();
                EventAggregator.PublishOnCurrentThread(FotoCollection);
                MainPanel = null;
                NotifyMainPanel();
                NotifyCanOk();
            }
        }

        public void Cancel()
        {
            MainPanel = null;
            SelectPaperPanel = null;
            FotoCollection = null;
            var order = NewOrder.New_Order;
            order.DeleteNewOrders();
            NotifyCanOk();
            NotifyMainPanel();
            NotifySelectPaperPanel();
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
            _activOkButton = message;
            NotifyOfPropertyChange(() => CanOk);
        }
        #endregion

        #region WMIEvent
        private void ActivWmiEvent()
        {
            AddInsertMemmoryCardHandler();
            AddRemoveMemmoryCardHandler();
            AddInsertUSBHandler();
            AddRemoveUSBHandler();
            AddRemoweInsertCdRomHandler();
        }

        #region Cdrom

        public void AddRemoweInsertCdRomHandler()
        {
            ManagementEventWatcher w = null;
            WqlEventQuery q;
            var observer = new
                ManagementOperationObserver();

            // Bind to local machine
            var opt = new ConnectionOptions();
            opt.EnablePrivileges = true; //sets required privilege
            var scope = new ManagementScope("root\\CIMV2", opt);

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceModificationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 1);

                // DriveType - 5: CDROM
                q.Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5";
                w = new ManagementEventWatcher(scope, q);

                // register async. event handler
                w.EventArrived += CdrEventArrived;
                w.Start();

                // Do something usefull,block thread for testing
                Console.ReadLine();
            }
            catch (System.Exception)
            {
            }
            finally
            {
                w.Stop();
            }
        }

        #endregion

        #region USB

        public void AddRemoveUSBHandler()
        {
            ManagementEventWatcher w = null;

            WqlEventQuery q;
            var opt = new ConnectionOptions();

            var scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceDeletionEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += USBRemoved;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        public void AddInsertUSBHandler()
        {
            ManagementEventWatcher w = null;

            var observer = new ManagementOperationObserver();

            WqlEventQuery q;

            var scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceCreationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += USBInserted;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        #endregion

        #region MemmoryCard

        public void AddRemoveMemmoryCardHandler()
        {
            ManagementEventWatcher w = null;

            WqlEventQuery q;
            var opt = new ConnectionOptions();

            var scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceDeletionEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_PhysicalMedia'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += MemmoryCartRemoved;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        public void AddInsertMemmoryCardHandler()
        {
            ManagementEventWatcher w = null;

            var observer = new ManagementOperationObserver();

            WqlEventQuery q;
            var opt = new ConnectionOptions();

            var scope = new ManagementScope("root\\CIMV2", opt);
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceCreationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_PhysicalMedia'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += MemmoryCartInserted;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        #endregion

        private void USBInserted(object sender, System.EventArgs e)
        {
            _activUsb1 = true;
            _activUsb2 = true;
            NotifyOfPropertyChange((() => CanUsb1));
            NotifyOfPropertyChange((() => CanUsb2));
        }

        private void USBRemoved(object sender, System.EventArgs e)
        {
            _activUsb1 = false;
            _activUsb2 = false;
            NotifyOfPropertyChange((() => CanUsb1));
            NotifyOfPropertyChange((() => CanUsb2));
        }
        private void MemmoryCartInserted(object sender, System.EventArgs e)
        {
            _activMemmoryCard = true;
            NotifyOfPropertyChange((() => CanCart));
        }

        private void MemmoryCartRemoved(object sender, System.EventArgs e)
        {
            _activMemmoryCard = false;
            NotifyOfPropertyChange((() => CanCart));
        }

        private void CdrEventArrived(object sender, EventArrivedEventArgs e)
        {
            var pd = e.NewEvent.Properties["TargetInstance"];

            if (pd != null)
            {
                var mbo = pd.Value as ManagementBaseObject;
                if (mbo.Properties["VolumeName"].Value != null)
                {
                    _activCd = true;
                    NotifyOfPropertyChange((() => CanCd));
                }
            }
            else
            {
                _activCd = false;
                NotifyOfPropertyChange((() => CanCd));
            }
        }
        #endregion

    }
}
