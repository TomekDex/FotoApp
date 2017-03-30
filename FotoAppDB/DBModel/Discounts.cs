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
        [Key]
        [ForeignKey("Papers")]
        public int PaperID { get; set; }
        [Key]
        public int Quantity { get; set; }
        public double Discount { get; set; }
        
    }
}
