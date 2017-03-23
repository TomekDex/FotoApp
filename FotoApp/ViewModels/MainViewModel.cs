using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace FotoApp.ViewModels
{
    class MainViewModel : PropertyChangedBase
    {
        private const string WindowTitleDefault = "FotoApp";
        private string _windowTitle = WindowTitleDefault;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                NotifyOfPropertyChange(() => WindowTitle);
            }
        }
    }
}
