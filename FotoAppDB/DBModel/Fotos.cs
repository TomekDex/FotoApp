using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    class Fotos
    {
        public int FotoID { get; set; }
        public int OrderID { get; set; }
        public int PaperID { get; set; }
        public int Quantity { get; set; }
        public string URL { get; set; }
    }
}
