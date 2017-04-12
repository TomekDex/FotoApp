using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using FotoApp.Controls;
using FotoApp.Schell;
using FotoApp.ViewModels;

namespace FotoApp
{
    class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<SchellViewModel>();
        }
    }
}
