using System;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Schell;
using FotoApp.Schell.EventArgs;

namespace FotoApp.ViewModels
{
    public class StartViewModel : Screen, IViewModelEventAggregator, IViewModel
    {
        public IEventAggregator EventAggregator { get; set; }
        private readonly SchellViewModel _schell;

        public IViewModel MainPanel
        {
            get { return MainPanel; } 
            set
            {
                MainPanel = value;
                NotifyOfPropertyChange(() => MainPanel);
            }
        }

        public delegate void OnCosingDelegate();

        public event OnCosingDelegate OnClosing;

        #region Proportis

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanBtnLogIn);
            }
        }

        #endregion

        #region Constractor

        public StartViewModel(SchellViewModel schel, IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            _schell = schel;
        }

        #endregion

        #region Actions

        public void BtnLogIn()
        {
            var log = new StartOrClose();

            if (null == OnClosing)
            {
                var hendler = new LogInHendler();
                log.startOrCloseDelegate += hendler.StartOrClose;
                log.OnStart(_schell, Password);
                NotifyOfPropertyChange(() => MainPanel);
            }
            else
            {
                var hendler = new OnColseHendler();
                log.startOrCloseDelegate += hendler.OnClosing;
                log.OnStart(null, Password);
            }
        }

        #endregion

        #region CanActions

        public bool CanBtnLogIn => !string.IsNullOrEmpty(Password);

        #endregion

    }
}
