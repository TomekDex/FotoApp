using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FotoApp.ViewModels
{
    public class DispatherService
    {
        public static void Invoke(Action a)
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;
            if (dispatcher == null || dispatcher.CheckAccess())
            {
                a();
            }
            else
            {
                dispatcher.Invoke(a);
            }
        }
    }
}
