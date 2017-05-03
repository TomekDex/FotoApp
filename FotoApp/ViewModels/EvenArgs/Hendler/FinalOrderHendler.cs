using System;
using FotoApp.ViewModels.EvenArgs.Args;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs.Hendler
{
    public class FinalOrderHendler
    {
        public void FinalOrder(object sender, EventArgs e)
        {
            var tmp = e as FinalOrderArgs;
            var finalOreder = sender as GetFotoViewModel;

            if (finalOreder == null) throw new NullGetFotoException("Brak widoku model");

            if (tmp == null) throw new NullListFotoException("brak danych kontaktowych");

           /* finalOreder.FotoCollection.CustomerName = tmp.Name;
            finalOreder.FotoCollection.CustomerMail = tmp.Mail;
            finalOreder.FotoCollection.CustomerPhoneNumber = tmp.Phone;*/
        }
    }
}
