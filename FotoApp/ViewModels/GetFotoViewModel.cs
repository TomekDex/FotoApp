using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.FotoColection;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;
using Sundew.Core.Messaging;

namespace FotoApp.ViewModels
{
    public sealed class GetFotoViewModel : Screen, IViewModelEventAggregator, IViewModel, IHandle<bool>
    {
        public delegate void Raports();

        public event Raports raport;
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }
        public IViewModel RightPanel { get; set; }
        public IViewModel LeftPanel { get; set; }
        public IViewModel RaportPanel { get; set; }

        #region  Propertis

        private bool _closingOrder;
        private bool? _activOkButton;
        private DriveInfo drivoInfo;
        private SchellViewModel schell;

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
        }

        #endregion

        #region  Actions

        public void ActivMainPanel(DriveInfo path)
        {
            var m = new ListFotoViewModel(this);
            MainPanel = m;
            m.activCheckBox += ActivLeftPanel;
            m.activCheckBox += ActiveRightPanel;
            m.changeOrder += Raport;

            var r = new ChangePapersAndSiseViewModel(this);
            RightPanel = r;
            r.changePapers += ActiveRightPanel;

            _closingOrder = false;
            NotifyPanel();
            EventAggregator.PublishOnCurrentThread(path);
        }

        private void Raport()
        {
            OnRaport();
        }

        private void ActivLeftPanel()
        {
            var f = new FotoInfoViewModel(this);
            LeftPanel = f;
            var r = new RaportViewModel(this);
            RaportPanel = r;
            f.changeOrder += Raport;
            var m = MainPanel as ListFotoViewModel;
            m.activCheckBox -= ActivLeftPanel;
            NotifyPanel();
        }

        private void ActiveRightPanel()
        {

            var r = RightPanel as ChangePapersAndSiseViewModel;
            if (r == null) return;
            r.changePapers -= ActiveRightPanel;
            var o = new OrderViewModel(this);
            RightPanel = o;
            o.changeOrder += Raport;
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
                var main = new AndOrderViewModel(null);
                MainPanel = main;
                main.andOrder += AndOrder;
                LeftPanel = null;
                RightPanel = null;
                NotifyPanel();
                NotifyCanOk();
                var task = new Task(action: AndOrder);
                task.Start();
            }
        }

        private void AndOrder()
        {
            Thread.Sleep(new TimeSpan(0,0,10));
            MainPanel = null;
            NotifyPanel();
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
            NotifyOfPropertyChange(()=> RaportPanel);
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

        private void OnRaport()
        {
            raport?.Invoke();
        }
        #endregion
    }
}
