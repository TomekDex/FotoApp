using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs
{
    public class GetPaper
    {
        public delegate void GetPaperDelegate(object sender, EventArgs e);

        public event GetPaperDelegate getChoicePaper = null;

        public void GetCoicePaper(object listFoto, int type, Sizes size)
        {
            var tmp = new GetPaperArgs(type, size);
            ReservationGetFotoArgs(type, tmp);
        }

        private void ReservationGetFotoArgs(object sender, EventArgs e)
        {
            if (sender == null) throw new NullGetFotoException("Brak widoku model");

            if (e == null) throw new NullListFotoException("Brak zdiec do zamuwienia");

            if (null != getChoicePaper)
            {
                getChoicePaper(sender, e);
            }
        }
    }
}
