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

namespace FotoApp.ViewModels
{
    public class StartViewModel : PropertyChangedBase, ISchellable
    {
        public SchellViewModel Schell { get; set; }

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

        public StartViewModel(SchellViewModel schell)
        {
            Schell = schell;

        }

        public void BtnLogIn()
        {
            if (Password == Properties.Resources.Password)
            {
                Schell.ActivateItem(new GetFotoViewModel(Schell));
            }
        }

        public bool CanBtnLogIn
        {
            get
            {
                return !string.IsNullOrEmpty(Password);
            }
        }
    }
}
