using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.ViewModels;

namespace FotoApp.Schell
{
    public class SchellViewModel: Screen, IViewModelEventAggregator, IViewModel
    {
        private bool _onClose;
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }

        public SchellViewModel()
        {
            EventAggregator = new EventAggregator();
            _onClose = false;
           MainPanel = new StartViewModel(EventAggregator);
            base.DisplayName = "FotoApp";
#if DEBUG
            MainPanel = new GetFotoViewModel(EventAggregator);
#endif
        }

        public void OnClose()
        {

        }

        //public sealed override void ActivateItem(object item)
        //{
        //    //base.ActivateItem(item);
        //}

        public void OnClosing()
        {
#if DEBUG
            Application.Current.Shutdown();
#endif
            var start = new StartViewModel(EventAggregator);
            _onClose = true;
            start.onClosing += OnClose;
            //ActivateItem(start);
        }

    }
}
