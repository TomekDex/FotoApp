using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ChangePapersAndSiseViewModel : Screen, IViewModelEventAggregator, IViewModel
    {
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }

        #region Proportis

        private BindableCollection<Sizes> _siseList;
        private BindableCollection<Types> _typeList;
        private int _type;
        private Sizes _sise;
        private GetPapers _papers;
        public BindableCollection<Sizes> SizeList
        {
            get => _siseList;
            set
            {
                _siseList = value;
                NotifyOfPropertyChange(() => SizeList);
            }
        }

        public BindableCollection<Types> TypeList
        {
            get => _typeList;
            set
            {
                _typeList = value;
                NotifyOfPropertyChange(() => TypeList);
            }
        }

        #endregion

        #region Constraktor

        public ChangePapersAndSiseViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
#if DEBUG
            _papers = new GetPapers();
            TypeList = _papers.GetTypes();
            //Inicialise();
#endif
        }

        #endregion

        #region Actions

        public void ChangeType(object o)
        {
            _siseList = new BindableCollection<Sizes>();
            var tmp = o as Types;
            if (tmp != null)
            {
                SizeList = _papers.GetSizes(_papers.GetTypeByIndex(tmp.id));
            }
            NotifyOfPropertyChange(()=> SizeList);
        }

        public void ChangeSize(object o)
        {
            var tmp = o as Sizes;
            if (tmp != null)
            {
                _sise = tmp;
            }
            EventAggregator.PublishOnCurrentThread(SendPapers());
        }

        #endregion

        private IEnumerable<object> SendPapers()
        {
            
            yield return _type;
            yield return _sise;
        }

        public BindableCollection<Types> GetTypse()
        {
            return TypeList;
        }

        public BindableCollection<Sizes> GetSizesByTypes(object o)
        {
            _siseList = new BindableCollection<Sizes>();
            object getSizes = null;
            var tmp = o as Types;
            if (tmp != null)
            {
                 getSizes = _papers.GetSizes(_papers.GetTypeByIndex(tmp.id));
            }
            return (BindableCollection<Sizes>) getSizes;
        }

#if DEBUG

        private void Inicialise()
        {
            var init = new InitPapers();
            TypeList = init.peperList;
        }

#endif

    }
}
