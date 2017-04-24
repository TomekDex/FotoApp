namespace FotoApp.Pref
{
    public class Preference
    {
        private static object _o = new object();
        private static Preference _preference;
        private static string _defaulPath;
        private static string _lag;
        private static string _typeFoto;
        private Preference()
        {
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
                lock (_o)
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
            get { return _defaulPath; } 
            set { _defaulPath = value; }
        }

        public static string Lang {
            get { return _lag; }
            set { _lag = value; }
        }
        public static string TypeFoto {
            get { return _typeFoto; }
            set { _typeFoto = value; }
        }
    }
}
