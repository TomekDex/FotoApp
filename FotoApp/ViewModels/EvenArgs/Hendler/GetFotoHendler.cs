using System;
using FotoApp.ViewModels.EvenArgs.Args;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs.Hendler
{
    public class GetFotoHendler
    {
        public void GetGoto(object sender, EventArgs e)
        {
            var tmp = e as GetFotoArgs;
            var tmpGetFoto = sender as GetFotoViewModel;

            if (tmpGetFoto == null) throw new NullGetFotoException("Brak widoku model");

            if (tmp == null) throw new NullListFotoException("Brak zdiec do zamuwienia");
            
            //*/tmpGetFoto.FotoCollection = tmp.FinalColections;
        }
    }
}
