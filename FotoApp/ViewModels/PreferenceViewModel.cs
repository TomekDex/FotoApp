using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Windows;
using FotoApp.Pref;
using FotoApp.Pref.Helpers;
using FotoApp.Schell;
using FotoApp.ViewModels.Validation;

namespace FotoApp.ViewModels
{
    public class PreferenceViewModel: ViewModelBase.ViewModelBase
    {
        #region Constractor

        public PreferenceViewModel( ) : base(null)
        {
            _typeFile = Preference.TypeFoto;
            _defaulPath = Preference.DefaultPath;
            _lag = Preference.Lang;
        }
        #endregion

        #region Proportis
        private  string _defaulPath;
        private  string _lag;
        private  string _typeFile;
        private bool _change = true;
        private bool _boolPath = false;
        private bool _boolLang = false;
        private bool _boolType = false;

        [Required (ErrorMessage = "Pole nie ma wartości")]
        [CustomValidation(typeof(PathValidation), "IsValid")]
        public string DefaultPath
        {
            get { return _defaulPath; }
            set
            {
                _defaulPath = value;
                _boolPath = true;
                _change = false;
                NotifyOfPropertyChange(()=> DefaultPath);
                NotifyOfPropertyChange(()=> CanOkPath);
                NotifyOfPropertyChange((() => CanOk));
            }
        }
        [Required(ErrorMessage = "Pole nie ma wartości")]
        public string Lang
        {
            get { return _lag; }
            set
            {
                _lag= value;
                _boolLang = true;
                _change = false;
                NotifyOfPropertyChange(() => Lang);
                NotifyOfPropertyChange((() => CanOkLang));
                NotifyOfPropertyChange((() => CanOk));
            }
        }
        [Required(ErrorMessage = "Pole nie ma wartości")]
        [CustomValidation(typeof(TypeValidation), "IsValid")]
        public string TypeFile
        {
            get { return _typeFile; }
            set
            {
                _typeFile = value;
                _boolType = true;
                _change = false;
                NotifyOfPropertyChange(() => TypeFile);
                NotifyOfPropertyChange((() => CanOkType));
                NotifyOfPropertyChange((() => CanOk));
            }
        }

        #endregion

        #region CanProportis
        
        public bool CanOkPath => _boolPath == true;

        public bool CanOkType => _boolType == true;

        public bool CanOkLang => _boolLang == true;
        public bool CanOk => _boolLang == true;


        #endregion

        #region Actions

        public void OkPath()
        {
            var tmp = new PreferenceHelper();
            tmp.UpdateSetings("Path", DefaultPath);
        }
        public void OkType()
        {
            var tmp = new PreferenceHelper();
            tmp.UpdateSetings("Type", TypeFile);
        }
        public void OkLang()
        {
            var tmp = new PreferenceHelper();
            tmp.UpdateSetings("Lang", Lang);
        }
        public void Ok()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        #endregion
    }
}
