using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Models;
using FotoApp.Schell;
using FotoApp.ViewModels.Debug;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel :PropertyChangedBase, ISchellable
    {
        public SchellViewModel Schell { get; set; }

        private BindableCollection<Data> data;
        private GetFotoViewModel getFoto;
        public ListFotoViewModel(SchellViewModel schellViewModel, GetFotoViewModel getFotoViewModel)
        {
            Schell = schellViewModel;
            getFoto = getFotoViewModel;
            data = getFotoViewModel.FotoCollection;
            Additems items = new Additems();
            items.Inicialice();
            data = items.data;
        }

        
    }
}
