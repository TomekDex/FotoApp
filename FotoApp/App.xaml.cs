using System.Windows;
using FotoApp.Schell.Actions;

namespace FotoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            ActiveAltCtrlDel.EnableTaskManager();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DeActiveAltCtrlDel.DisableTaskManager();
        }
    }
}
