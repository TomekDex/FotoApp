using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.ChangePapersAnSiseModel;

namespace FotoApp.ViewModels
{
    public class ChangePapersAndSiseViewModel :PropertyChangedBase, IViewModelEventAggregator, IViewModel
    {
        public ChangePapersAndSiseViewModel()
        {
#if DEBUG
            Inicialise();
#endif
        }
#if DEBUG
        private void Inicialise()
        {
            InitPapers init = new InitPapers();
            TypeList = init.peperList;
        }
#endif

        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }

        public BindableCollection<Sizes> SiseList { get; private set; }
        public BindableCollection<Types> TypeList { get; set; }

    }
}
