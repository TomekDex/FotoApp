using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel :PropertyChangedBase, ISchellable
    {
        public SchellViewModel Schell { get; set; }

        private GetFotoViewModel getFoto;
        public ListFotoViewModel(SchellViewModel schellViewModel, GetFotoViewModel getFotoViewModel)
        {
            Schell = schellViewModel;
            getFoto = getFotoViewModel;
        }

        
    }
}
