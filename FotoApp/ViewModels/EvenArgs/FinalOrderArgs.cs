using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.EvenArgs
{
    public class FinalOrderArgs : EventArgs
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public  string Mail { get; private set; }

        public FinalOrderArgs(string name, string phone, string mail)
        {
            Name = name;
            Phone = phone;
            Mail = mail;
        }
    }
}
