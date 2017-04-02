using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.Models
{
    public class FinalColection
    {
        public List<FinalFoto> FotoColection { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEMail { get; set; }

        public FinalColection()
        {
                FotoColection = new List<FinalFoto>();
        }
    }
}
