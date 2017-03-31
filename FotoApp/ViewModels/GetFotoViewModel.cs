using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel : ISchellable
    {
        public SchellViewModel Schell { get; set; }

        public GetFotoViewModel(SchellViewModel schell)
        {
            Schell = schell;
        }

        public void Usb1()
        {

        }

        public bool CanUsb1()
        {
            return true;
        }
        public void Usb2()
        {

        }

        public bool CanUsb2()
        {
            return true;
        }
        public void Cd()
        {

        }

        public bool CanCd()
        {
            return true;
        }
        public void Cart()
        {

        }

        public bool CanCart()
        {
            return true;
        }
        public void Ok()
        {

        }

        public bool CanOk()
        {
            return true;
        }
    }
}
