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
    public sealed class ChangePapersAndSiseViewModel : ViewModelBase.ViewModelBase
    {
        public delegate void ChangePapers();
        public event ChangePapers changePapers;
        #region Proportis

        private BindableCollection<SizeM> _siseList;
        private BindableCollection<Types> _typeList;
        private GetPapers _detPapers;
        private Papers _papers;
        public BindableCollection<SizeM> SizeList
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

        public ChangePapersAndSiseViewModel(GetFotoViewModel getFoto)
            : base(getFoto)
        {
            _detPapers = new GetPapers();
            _papers = new Papers();
            _siseList = _detPapers.GetSizes();
        }

        #endregion

        #region Actions

        public void ChangeType(object o)
        {
            var tmp = o as Types;
            if (tmp != null)
            {
                _papers.TypeID = tmp.id;
            }
            EventAgg.Agregator.EventAggregator.PublishOnCurrentThread(_papers);
            OnChangePapers();
        }

        public void ChangeSize(object o)
        {
            if (changePapers !=null)
            {
                var tmp = o as SizeM;
                var tmpSizes = new Sizes
                {
                    Height = tmp.Height,
                    Width = tmp.Width
                };
                if (tmp != null)
                {
                    TypeList = _detPapers.GetTypesBySize(tmpSizes);
                }
                _papers.Height = tmp.Height;
                _papers.Width = tmp.Width;
                NotifyOfPropertyChange(() => TypeList);
            }
        }

        #endregion

        private void OnChangePapers()
        {
            changePapers?.Invoke();
        }
    }
}
