using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.Schell.EventArgs
{
    class PasswordArgs : System.EventArgs
    {
        public string Password { get; private set; }

        public PasswordArgs(string password)
        {
            Password = password;
        }
    }
}
