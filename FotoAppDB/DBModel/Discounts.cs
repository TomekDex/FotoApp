using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Discounts
    {
        [Key, Column(Order = 1), ForeignKey("Papers")]
        public int PaperID { get; set; }
        [Key, Column(Order = 2)]
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public Papers Papers { get; set; }

    }
}
