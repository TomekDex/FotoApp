using Caliburn.Micro;

namespace FotoApp.Models.ChangePapersAnSiseModel
{
    public class Types
    {
        public int id { get; set; }
        public  string Type { get; set; }
        public BindableCollection<SizeM> listSises { get; set; }

    }
}
