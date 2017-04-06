using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.Schell.EventArgs
{
    public class StartOrClose
    {
        public delegate void StartOrCloseDelegate(object sender, System.EventArgs e);

        public event StartOrCloseDelegate startOrCloseDelegate ;
        public void OnStart(SchellViewModel schell, string password)
        {
            PasswordArgs pass = new PasswordArgs(password);
            ReservationPassArgs(schell, pass);
        }

        private void ReservationPassArgs(SchellViewModel schell, PasswordArgs e)
        {
            if (null != startOrCloseDelegate)
            {
                startOrCloseDelegate(schell, e);
            }
        }

        
    }
}
