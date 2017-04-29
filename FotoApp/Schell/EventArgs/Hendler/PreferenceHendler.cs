using FotoApp.Properties;
using FotoApp.Schell.EventArgs.Args;
using FotoApp.ViewModels;

namespace FotoApp.Schell.EventArgs.Hendler
{
    public class PreferenceHendler
    {
        public void OnPreference(object sender, System.EventArgs e)
        {
            var pass = e as PasswordArgs;

            var schell = sender as SchellViewModel;

            if (pass != null && pass.Password == Resources.Password)
            {
                schell?.ActivateItem(new PreferenceViewModel());
            }
        }
    }
}
