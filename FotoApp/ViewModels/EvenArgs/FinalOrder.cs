using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs
{
    public class FinalOrder
    {
        public delegate void FinaOrderDelegate(object sender, EventArgs e);

        public event FinaOrderDelegate finalOrderDelegate = null;
        public void GetFotoColection(object getFoto, string name,string phone, string mail)
        {
            var tmp = new FinalOrderArgs(name,phone,mail);
            ReservationGetFotoArgs(getFoto, tmp);
        }
        private void ReservationGetFotoArgs(object sender, EventArgs e)
        {
            if (sender == null) throw new NullGetFotoException("Brak widoku model");

            if (e == null) throw new NullListFotoException("Brk wybranego Papieru");

            if (null != finalOrderDelegate)
            {
                finalOrderDelegate(sender, e);
            }
        }
    }
}
