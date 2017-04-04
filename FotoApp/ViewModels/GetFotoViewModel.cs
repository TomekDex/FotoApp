using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class GetFotoViewModel : ISchellable
    {
        public SchellViewModel Schell { get; set; }

        public GetFotoViewModel(SchellViewModel schell)
        {
            Schell = schell;
        }
    }
}
