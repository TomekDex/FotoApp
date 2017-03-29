using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    class Discounts
    {
        public int FotoID { get; set; }
        public int PaperID { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
    }
}
