using FotoApp.Pref.Helpers;

namespace FotoApp.Pref
{
    public class Preference
    {
        private static readonly object O = new object();
        private static Preference _preference;
        private static string _defaulPath;
        private static string _lag;
        private static string _typeFoto;
        private Preference()
        {
            var tmp = new PreferenceHelper();
            _typeFoto = tmp.GetSetings("Type");
            _defaulPath = tmp.GetSetings("Path");
            _lag = tmp.GetSetings("Lang");
#if DEBUG
            _defaulPath = @"C:\";
            _lag = "pl_Pl";
           _typeFoto = "jpg/tif/raw/psd";
#endif
        }

        public static Preference Preferenc
        {
            get
            {
                lock (O)
                {
                    if (null == _preference)
                    {
                        _preference = new Preference();
                    }
                }
                return _preference;
            }
        }

        public static string DefaultPath
        {
            get => _defaulPath;
            set => _defaulPath = value;
        }

        public static string Lang {
            get => _lag;
            set => _lag = value;
        }
        public static string TypeFoto {
            get => _typeFoto;
            set => _typeFoto = value;
        }
    }
}
