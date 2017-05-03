using FotoApp.Schell.EventArgs.Args;

namespace FotoApp.Schell.EventArgs
{
    public class StartOrClose
    {
        public delegate void StartOrCloseDelegate(object sender, System.EventArgs e);

        public event StartOrCloseDelegate startOrCloseDelegate ;
        public void OnStart(object schell, string password)
        {
            PasswordArgs pass = new PasswordArgs(password);
            ReservationPassArgs(schell, pass);
        }

        private void ReservationPassArgs(object schell, PasswordArgs e)
        {
            startOrCloseDelegate?.Invoke(schell, e);
        }

        
    }
}
