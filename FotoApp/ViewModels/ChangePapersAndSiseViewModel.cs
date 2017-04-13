using System.Collections.Generic;
using Caliburn.Micro;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ChangePapersAndSiseViewModel : ViewModelBase.ViewModelBase, IHandle<ListFotoViewModel>
    {
        private ListFotoViewModel _listFoto;
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

        public ChangePapersAndSiseViewModel(GetFotoViewModel getFoto, IEventAggregator eventAggregator, ListFotoViewModel listFoto) 
            :base(getFoto, eventAggregator)
        {
            _listFoto = listFoto;
            _listFoto.getPaperDelegete += GetPaper;

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
        public void GetPaper()
        {
            var tmp = new GetPaper();
            var hendler = new GetPaperHendler();
            tmp.getChoicePaper += hendler.GetPaper;
            tmp.GetCoicePaper(_listFoto, _type, _sise);
        }

        public void Handle(ListFotoViewModel message)
        {
            _listFoto = message;
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
