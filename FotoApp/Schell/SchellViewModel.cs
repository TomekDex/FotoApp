using System.Windows;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.ViewModels;

namespace FotoApp.Schell
{
    public class SchellViewModel: Conductor<object>, IViewModelEventAggregator
    {
        private bool _onClose;
        public IEventAggregator EventAggregator { get; set; }

        public SchellViewModel()
        {
            EventAggregator = new EventAggregator();
            _onClose = false;
            ActivateItem(new StartViewModel(this, EventAggregator));
            base.DisplayName = "FotoApp";
#if DEBUG
            ActivateItem(new GetFotoViewModel(this, EventAggregator));
#endif
        }

        public sealed override void ActivateItem(object item)
        {
            base.ActivateItem(item);
        }

        public void OnClose()
        {

        }

        public void OnClosing()
        {
#if DEBUG
            Application.Current.Shutdown();
#endif
            var start = new StartViewModel(this,EventAggregator);
            _onClose = true;
            start.OnClosing += OnClose;
            ActivateItem(start);
        }

    }
}
