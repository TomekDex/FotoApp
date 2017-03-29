using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    class Papers
    {
        public int PaperID { get; set; }
        public string Size { get; set; }
        public string Paper { get; set; }
        public double Cost { get; set; }
    }
}
