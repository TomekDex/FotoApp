using System.Windows.Media.Imaging;
using FotoAppDB.DBModel;

namespace FotoApp.Models.FotoColection
{
    public class OrderFoto
    {
        public Fotos Foto { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public BitmapImage Image { get; set; }
        public Papers Paper { get; set; }

    }
}
