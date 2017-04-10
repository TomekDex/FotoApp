using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ChangePapersAndSiseViewModel :Screen, IViewModelEventAggregator, IViewModel
    {
#if DEBUG
        private void Inicialise()
        {
            InitPapers init = new InitPapers();
            TypeList = init.peperList;
        }
#endif
        #region Constraktor
        public ChangePapersAndSiseViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
#if DEBUG
            Inicialise();
#endif
        }
        #endregion
       
        public IEventAggregator EventAggregator { get; set; }
        public IViewModel MainPanel { get; set; }

        #region Proportis
        private BindableCollection<Sizes> _siseList;
        private BindableCollection<Types> _typeList;
        private int _type;
        private int _sise;
        public BindableCollection<Sizes> SizeList
        {
            get { return _siseList; }
            set
            {
                _siseList = value;
                NotifyOfPropertyChange(() => SizeList);

            }
        }

        public BindableCollection<Types> TypeList
        {
            get { return _typeList; }
            set
            {
                _typeList = value;
                NotifyOfPropertyChange(() => TypeList);
            }
        }

        #endregion
        #region Actions
        public void ChangeType(object o)
        {
            _siseList = new BindableCollection<Sizes>();
            var tmp = o as Types;
            if (tmp != null)
            {
                _type = tmp.id;
                SizeList = tmp.listSises;
            }
        }

        public void ChangeSize(object o)
        {
            var tmp = o as Sizes;
            if (tmp != null) _sise = tmp.id;
            EventAggregator.PublishOnCurrentThread(GetType());
        }
        #endregion
       
        private  IEnumerable<int> GetType()
        {
            yield return _type;
            yield return _sise;
        }
    }
}
