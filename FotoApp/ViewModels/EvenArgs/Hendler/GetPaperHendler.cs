using System;
using FotoApp.ViewModels.EvenArgs.Args;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs.Hendler
{
    public class GetPaperHendler
    {
        public void GetPaper(object sender, EventArgs e)
        {
            var tmpGetPaper = sender as ListFotoViewModel;
            var tmpArgs = e as GetPaperArgs;

            if (tmpGetPaper == null) throw  new NullListFotoException("Brak vidoku model");
            if (tmpArgs == null) throw  new NullGetPaperExceptin("Nie wybrana rodzaju papieru");

            tmpGetPaper.Type = tmpArgs._type;
            tmpGetPaper.Sise = tmpArgs.SizeM;
        }
    }
}
