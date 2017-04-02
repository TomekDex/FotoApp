using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Models;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel :Conductor<object>, ISchellable
    {
        public SchellViewModel Schell { get; set; }
        public  FinalColection FotoCollection { get; set; }
        #region  Propertis
        
        private string price;
        private string discount;
        private int count = 12;

        public string Price
        {
            get { return price; }
            set
            {
                price =  value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public string Discount
        {
            get { return discount; }
            set
            {
                discount =  value;
                NotifyOfPropertyChange(() => Discount);
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                NotifyOfPropertyChange(() => Count);
            }
        }
        #endregion

        #region Constractor
        public GetFotoViewModel(SchellViewModel schell)
        {
            Schell = schell;

#if DEBUG
            discount = "kjsdhsdkjfhsdkfs";
            price = "klsdfjskdfhsdf";
#endif
        }
        #endregion

        #region  Actions
        public void Usb1()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
        }
        public void Usb2()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
        }
        public void Cd()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
        }
        public void Cart()
        {
            ActivateItem(new ListFotoViewModel(Schell, this));
        }
        public void Ok()
        {
            ActivateItem(null); // wczytanie danych z do zatwierdzenia zlecenia 
        }
        #endregion

        #region CanActions
        public bool CanUsb1()
        {
            return true;
        }
        public bool CanUsb2()
        {
            return true;
        }
        public bool CanCd()
        {
            return true;
        }
        public bool CanCart()
        {
            return true;
        }
        public bool CanOk()
        {
            return true;
        }
        #endregion

    }
}
