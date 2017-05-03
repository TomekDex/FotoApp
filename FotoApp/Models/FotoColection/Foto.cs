using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using FotoApp.Annotations;

namespace FotoApp.Models.FotoColection
{
    public class Foto : INotifyPropertyChanged
    {
        private BitmapImage _bitmap;
        public int Index { get; set; }
        public string path { get; set; }
        public BitmapImage bitmap
        {
            get => _bitmap;
            set
            {
                _bitmap = value;
                OnPropertyChanged(nameof(bitmap));
            } }
        public bool Chekerd { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
