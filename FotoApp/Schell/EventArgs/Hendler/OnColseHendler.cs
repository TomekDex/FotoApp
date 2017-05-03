using System.Windows;
using FotoApp.Schell.EventArgs.Args;

namespace FotoApp.Schell.EventArgs.Hendler
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
