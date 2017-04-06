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
        public void StartOrClose(object sender, System.EventArgs e)
        {
            PasswordArgs pass = e as PasswordArgs;

            var schell = sender as SchellViewModel;

            if (pass != null && pass.Password == Properties.Resources.Password)
            {
                schell?.ActivateItem(new GetFotoViewModel(schell));
            }
        }

    }
}
