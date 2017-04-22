using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class PreferenceViewModel: Screen, IViewModel, IViewModelEventAggregator
    {
        public IEventAggregator EventAggregator { get; set; }
        private SchellViewModel schell;

        #region Constractor

        public PreferenceViewModel(SchellViewModel schell, IEventAggregator eventAggregator)
        {
            this.schell = schell;
            EventAggregator = eventAggregator;
            _typeFoto = Preference.Preference.TypeFoto;
            _defaulPath = Preference.Preference.DefaultPath;
            _lag = Preference.Preference.Lang;
        }
        #endregion

        #region Proportis
        private  string _defaulPath;
        private  string _lag;
        private  string _typeFoto;
        private bool _boolPath = false;
        private bool _boolLang = false;
        private bool _boolType = false;
        public string DefaultPath
        {
            get { return _defaulPath; }
            set
            {
                _defaulPath = value;
                _boolPath = true;
                NotifyOfPropertyChange(()=> DefaultPath);
                NotifyOfPropertyChange(()=> CanOkPath);
            }
        }

        public  string Lang {
            get { return _lag; }
            set
            {
                _lag= value;
                _boolLang = true;
                NotifyOfPropertyChange(() => Lang);
                NotifyOfPropertyChange((() => CanOkLang));
            }
        }
        public  string TypeFoto {
            get { return _typeFoto; }
            set
            {
                _typeFoto = value;
                _boolType = true;
                NotifyOfPropertyChange(() => TypeFoto);
                NotifyOfPropertyChange((() => CanOkType));
            }
        }

        #endregion

        #region CanProportis
        
        public bool CanOkPath => _boolPath == true;

        public bool CanOkType => _boolType == true;

        public bool CanOkLang => _boolLang == true;


        #endregion
        #region Actions

        public void OkPath()
        {
            Preference.Preference.DefaultPath = DefaultPath;
        }
        public void OkType()
        {
            Preference.Preference.TypeFoto = TypeFoto;
        }
        public void OkLang()
        {
            Preference.Preference.Lang = Lang;
        }
        public void Ok()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        #endregion
    }
}
