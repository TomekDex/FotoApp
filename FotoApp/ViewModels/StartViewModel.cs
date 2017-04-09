using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using FotoApp.Controls;
using FotoApp.Interface;
using FotoApp.Schell;
using FotoApp.Schell.EventArgs;

namespace FotoApp.ViewModels
{
    public class StartViewModel : PropertyChangedBase, IViewModelEventAggregator, IViewModel
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }


        public delegate void OnCosingDelegate();

        public event OnCosingDelegate onClosing = null;
        #region Proportis

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(()=> CanBtnLogIn);
            }
        }

        #endregion

        #region Constractor
        public StartViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
        }
        #endregion

        #region Actions

        public void BtnLogIn()
        {
            var log = new StartOrClose();

            if (null == onClosing)
            {
                var hendler = new LogInHendler();
                log.startOrCloseDelegate += hendler.StartOrClose;
               // log.OnStart(Schell, Password);
            }
            else
            {
                var hendler = new OnColseHendler();
                log.startOrCloseDelegate += hendler.OnClosing;
                log.OnStart(null,Password);
            }
        }

        #endregion

        #region CanActions
        public bool CanBtnLogIn
        {
            get
            {
                return !string.IsNullOrEmpty(Password);
            }
        }
        #endregion

    }
}
