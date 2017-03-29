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
    public class Fotos
    {
        [Key]
        public int FotoID { get; set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        [ForeignKey("Pepers")]
        public int PaperID { get; set; }
        public int Quantity { get; set; }
        [MaxLength(50)]
        public string Path { get; set; }
    }
}
