using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Models;

namespace FotoApp.ViewModels.EvenArgs
{
    public class GetFotoArgs : EventArgs
    {
        public  FinalColection FinalColections { get; private set; }

        public GetFotoArgs(FinalColection finalColection)
        {
            FinalColections = finalColection;
        }
    }
}
