using System.Collections.Generic;
using Caliburn.Micro;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.Models.ChangePapersAnSiseModel
{
    public class Types
    {
        public int id { get; set; }
        public  string Type { get; set; }
        public BindableCollection<SizeM> listSises { get; set; }

    }
}
