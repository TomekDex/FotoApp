using System.Collections.Generic;

namespace FotoApp.Models.FotoColection
{
    public class FinalFotoColection
    {
        public List<FinalFoto> FotoColection { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerMail { get; set; }

        public FinalFotoColection()
        {
                FotoColection = new List<FinalFoto>();
        }
    }
}
