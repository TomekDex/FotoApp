using System.Collections.Generic;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;
using FotoAppDB.DBModel;
using Types = FotoApp.Models.ChangePapersAnSiseModel.Types;

namespace FotoApp.ViewModels
{
    public class ChangePapersAndSiseViewModel : Screen, IViewModel
    {
        public delegate void ChangePapers();
        public event ChangePapers changePapers;
        #region Proportis

        private BindableCollection<SizeM> _siseList;
        private BindableCollection<Types> _typeList;
        private int _type;
        private SizeM _sise;
        private GetPapers _papers;
        private Papers papers;
        public BindableCollection<SizeM> SizeList
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

        public ChangePapersAndSiseViewModel(GetFotoViewModel getFoto)
            //: base(getFoto)
        {
            _papers = new GetPapers();
            papers = new Papers();
            TypeList = _papers.GetTypes();
        }

        #endregion

        #region Actions

        public void ChangeType(object o)
        {
            _siseList = new BindableCollection<SizeM>();
            var tmp = o as Types;
            if (tmp != null)
            {
                SizeList = _papers.GetSizesByType(_papers.GetTypeByIndex(tmp.id));
            }
            NotifyOfPropertyChange(()=> SizeList);
            papers.TypeID = tmp.id;
        }

        public void ChangeSize(object o)
        {
            if (changePapers !=null)
            {
                var tmp = o as SizeM;
                if (tmp != null)
                {
                    _sise = tmp;
                }
                papers.Height = tmp.Height;
                papers.Length = tmp.Length;
                EventAgg.Agregator.EventAggregator.PublishOnCurrentThread(papers);
                changePapers?.Invoke();
            }
            
        }

        private void cos()
        {
            
        }
        #endregion
    }
}
