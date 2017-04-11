using FotoApp.Models.ChangePapersAnSiseModel;

namespace FotoApp.Models.FotoColection
{
    public class FinalFoto
    {
        public string NameOfFoto { get; set; }
        public string DestinationOfFoto { get; set; }
        public string FullPathOfFoto { get; set; }
        public int Type { get; set; }
        public Sizes Size { get; set; }
        public int NumbersOfFoto { get; set; }
        public int Index { get; set; }
    }
}
