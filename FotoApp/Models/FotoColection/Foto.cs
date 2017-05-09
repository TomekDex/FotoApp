using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using FotoApp.Annotations;

namespace FotoApp.Models.FotoColection
{
    public sealed class Foto : INotifyPropertyChanged
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
