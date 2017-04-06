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
        public void OnClosing(object sender, System.EventArgs e)
        {
            PasswordArgs pass = e as PasswordArgs;

            var schell = sender as SchellViewModel;

            if (pass != null && pass.Password == Properties.Resources.Password)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
