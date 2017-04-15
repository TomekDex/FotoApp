using System.Windows.Media.Imaging;

namespace FotoApp.Models.FotoColection
{
    public class Foto
    {
        public int Index { get; set; }
        public BitmapImage bitmap { get; set; }
        public bool Chekerd { get; set; }
    }
}
