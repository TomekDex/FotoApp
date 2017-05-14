using System.Windows;
using FotoApp.Schell.EventArgs.Args;
using FotoApp.ViewModels.Actions;

namespace FotoApp.Schell.EventArgs.Hendler
{
    public class OnColseHendler
    {
        public void  OnClosing(object sender, System.EventArgs e)
        {
            var pass = e as PasswordArgs;

            if (pass != null && pass.Password == Properties.Resources.Password)
            {
                var order = NewOrder.New_Order;
                order.DeleteNewOrders();
                Application.Current.Shutdown();
            }
        }
    }
}
