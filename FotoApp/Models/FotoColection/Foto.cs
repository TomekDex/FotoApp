using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Annotations;

namespace FotoApp.Models.FotoColection
{
    public class Foto: INotifyPropertyChanged
    {
        public int Index { get; set; }
        public string path { get; set; }
        public BitmapImage bitmap
        {
            get;
            set;
        }
        public bool Chekerd { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
