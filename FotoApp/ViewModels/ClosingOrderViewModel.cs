﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class ClosingOrderViewModel : PropertyChangedBase, ISchellable
    {
       

        #region Propertis
        public SchellViewModel Schell { get; set; }
        public GetFotoViewModel GetFoto { get; set; }

        private string _name;
        private string _phone;
        private string _mail;

        public string Name
        {
            get { return  _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(()=> Name);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }

        #endregion

        #region Constractor

        public ClosingOrderViewModel(SchellViewModel schell, GetFotoViewModel getFoto)
        {
            Schell = schell;
            GetFoto = getFoto;
            getFoto.ChangeNameDelegate += GetName;
            getFoto.ChangeMailDelegate += GetMail;
            getFoto.ChangePhoneDelegate += GetPhone;
        }


        #endregion

        #region Actions

        public string GetName()
        {
            return _name;
        }
        public string GetMail()
        {
            return _mail;
        }
        public string GetPhone()
        {
            return _phone;
        }


        #endregion
    }
}