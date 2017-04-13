﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs
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
            tmpGetPaper.Sise = tmpArgs._sizes;
        }
    }
}
