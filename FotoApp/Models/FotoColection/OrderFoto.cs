using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using FotoApp.Annotations;
using FotoAppDB.DBModel;

namespace FotoApp.Models.FotoColection
{
    public class OrderFoto: INotifyPropertyChanged
    {
        private string _size;
        private string _type;
        private int _quantity;
        public Fotos Foto { get; set; }
        public string Size {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            } }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public BitmapImage Image { get; set; }
        public Papers Paper { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
