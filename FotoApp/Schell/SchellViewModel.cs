using System;
using System.Net.Http;
using System.Windows;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Pref;
using FotoApp.ViewModels;

namespace FotoApp.Schell
{
    public class SchellViewModel: Conductor<object>, IViewModelEventAggregator
    {
        private bool _onClose;
        public IEventAggregator EventAggregator { get; set; }

        public SchellViewModel()
        {
            var EA = EventAgg.Agregator;
            EventAggregator = EA.EventAggregator;
            var pref = Preference.Preferenc;
            FirstStartFotoApp();
            _onClose = false;
            base.DisplayName = "FotoApp";
#if DEBUG
            ActivateItem(new GetFotoViewModel(this));
#endif
        }

        private void FirstStartFotoApp()
        {
            if (Preference.DefaultPath == String.Empty ||
                Preference.TypeFoto == String.Empty ||
                Preference.Lang == String.Empty ||
                Preference.DefaultPath == "?" ||
                Preference.TypeFoto == "?" ||
                Preference.Lang == "?")
            {
                var start = new StartViewModel(this, EventAggregator);
                start.OnPreference += OnClose;
                ActivateItem(start);
            }
            else
            {
                ActivateItem(new StartViewModel(this, EventAggregator));
            }
        }

        public sealed override void ActivateItem(object item)
        {
            base.ActivateItem(item);
        }

        private void OnClose()
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

        public  void OnPreference()
        {
            var start = new StartViewModel(this, EventAggregator);
            start.OnPreference += OnClose;
            ActivateItem(start);
        }

    }
}
