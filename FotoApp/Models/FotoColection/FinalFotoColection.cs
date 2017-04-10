using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.Models
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
