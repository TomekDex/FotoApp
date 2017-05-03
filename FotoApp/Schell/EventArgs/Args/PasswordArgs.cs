namespace FotoApp.Schell.EventArgs.Args
{
    public class PasswordArgs : System.EventArgs
    {
        public string Password { get; private set; }

        public PasswordArgs(string password)
        {
            Password = password;
        }
    }
}
