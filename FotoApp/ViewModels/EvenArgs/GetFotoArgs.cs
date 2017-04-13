using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Models;
using FotoApp.Models.FotoColection;

namespace FotoApp.ViewModels.EvenArgs
{
    public class GetFotoArgs : EventArgs
    {
        public  FinalFotoColection FinalColections { get; private set; }

        public GetFotoArgs(FinalFotoColection finalColection)
        {
            FinalColections = finalColection;
        }
    }
}
