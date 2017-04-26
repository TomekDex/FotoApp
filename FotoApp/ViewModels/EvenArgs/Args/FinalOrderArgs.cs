using System;

namespace FotoApp.ViewModels.EvenArgs.Args
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
