using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Properties;
using FotoApp.ViewModels;

namespace FotoApp.Schell.EventArgs
{
    public class LogInHendler
    {
        public void StartOrClose(object sender, System.EventArgs e)
        {
            var pass = e as PasswordArgs;

            var schell = sender as SchellViewModel;

            if (pass != null && pass.Password == Resources.Password)
            {
                schell?.ActivateItem(new GetFotoViewModel(schell, schell.EventAggregator));
            }
        }
    }
}
