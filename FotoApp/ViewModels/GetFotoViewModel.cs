using System;
using System.Collections.Generic;
using System.IO;
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
    public class GetFotoViewModel : Screen, IViewModelEventAggregator, IViewModel, IHandle<bool>
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }
        public IViewModel RightPanel { get; set; }
        public IViewModel LeftPanel { get; set; }

        #region  Propertis

        private string _price;
        private string _discount;
        private int _count = 12;
        private bool _closingOrder;
        private bool? _activOkButton;
        private DriveInfo drivoInfo;
        private SchellViewModel schell;

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

        public bool CanOk => _activOkButton == true;

        #endregion

        #region Constractor

        public GetFotoViewModel(SchellViewModel schell)
        {
            this.schell = schell;
            var EA = EventAgg.Agregator;
            MainPanel = new FlopyViewModel(this);
            EventAggregator = EA.EventAggregator;
            EventAggregator.Subscribe(this);
#if DEBUG
            _discount = "kjsdhsdkjfhsdkfs";
            _price = "klsdfjskdfhsdf";
#endif
        }

        #endregion

        #region  Actions

        public void ActivMainPanel(DriveInfo path)
        {
            var m = new ListFotoViewModel(this);
            MainPanel = m;
            m.activCheckBox += ActivLeftPanel;
            m.activCheckBox += ActiveRightPanel;

            var r = new ChangePapersAndSiseViewModel(this);
            RightPanel = r;
            r.changePapers += ActiveRightPanel;

            _closingOrder = false;
            NotifyPanel();
            EventAggregator.PublishOnCurrentThread(path);
        }

        private void ActivLeftPanel()
        {
            LeftPanel = new FotoInfoViewModel(this);
            var m = MainPanel as ListFotoViewModel;
            m.activCheckBox -= ActivLeftPanel;

            NotifyPanel();
        }

        private void ActiveRightPanel()
        {

            var r = RightPanel as ChangePapersAndSiseViewModel;
            if (r == null) return;
            r.changePapers -= ActiveRightPanel;
            RightPanel = new OrderViewModel(this);
            NotifyPanel();
        }

        public void Ok()
        {
            if (!_closingOrder)
            {
                _closingOrder = true;
                MainPanel = new ClosingOrderViewModel(this);
                NotifyPanel();
            }
            else
            {
                _closingOrder = false;
                _activOkButton = false;
                MainPanel = null;
                NotifyPanel();
                NotifyCanOk();
            }
        }

        public void Cancel()
        {
            MainPanel = null;
            LeftPanel = null;
            RightPanel = null;
            var order = NewOrder.New_Order;
            order.DeleteNewOrders();
            NotifyCanOk();
            NotifyPanel();
        }

        private void NotifyPanel()
        {
            NotifyOfPropertyChange(() => MainPanel);
            NotifyOfPropertyChange(() => RightPanel);
            NotifyOfPropertyChange(() => LeftPanel);
        }

        private void NotifyCanOk()
        {
            NotifyOfPropertyChange(() => CanOk);
        }

        public void Handle(bool message)
        {
            _activOkButton = message;
            NotifyOfPropertyChange(() => CanOk);
        }

        #endregion

       

    }
}
