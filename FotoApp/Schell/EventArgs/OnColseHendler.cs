using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FotoApp.Schell.EventArgs
{
    public class OnColseHendler
    {
        public void  OnClosing(object sender, System.EventArgs e)
        {
            var pass = e as PasswordArgs;

            if (pass != null && pass.Password == Properties.Resources.Password)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
