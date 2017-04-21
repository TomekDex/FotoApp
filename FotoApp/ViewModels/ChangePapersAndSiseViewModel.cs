using System.Collections.Generic;
using Caliburn.Micro;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ChangePapersAndSiseViewModel : ViewModelBase.ViewModelBase
    {
        #region Proportis

        private BindableCollection<Sizes> _siseList;
        private BindableCollection<Types> _typeList;
        private int _type;
        private Sizes _sise;
        private GetPapers _papers;
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
            get {return _typeList;}
            set
            {
                _typeList = value;
                NotifyOfPropertyChange(() => TypeList);
            }
        }

        #endregion

        #region Constraktor

        public ChangePapersAndSiseViewModel(GetFotoViewModel getFoto, IEventAggregator eventAggregator)
            : base(getFoto, eventAggregator)
        {

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
                SizeList = _papers.GetSizesByType(_papers.GetTypeByIndex(tmp.id));
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

        private IEnumerable<object> SendPapers()
        {
            yield return _type;
            yield return _sise;
        }

        public BindableCollection<Types> GetTypse()
        {
            return TypeList;
        }
        #endregion

#if DEBUG

        private void Inicialise()
        {
            var init = new InitPapers();
            TypeList = init.peperList;
        }
#endif
    }
}
