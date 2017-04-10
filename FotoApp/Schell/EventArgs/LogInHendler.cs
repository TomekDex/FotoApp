using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.ViewModels;

namespace FotoApp.Schell.EventArgs
{
    public class LogInHendler
    {
        public bool StartOrClose(object sender, System.EventArgs e)
        {
            PasswordArgs pass = e as PasswordArgs;

            var schell = sender as SchellViewModel;

            return pass.Password == Properties.Resources.Password;
            {
                //schell.MainPanel = new GetFotoViewModel(schell, schell.EventAggregator);
                
            }
        }

    }
}
