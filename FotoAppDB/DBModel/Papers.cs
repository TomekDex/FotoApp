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
    public class Papers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int PaperID { get; set; }
        [ForeignKey("Texts"), Required]
        public int Size { get; set; }
        [ForeignKey("Texts"), Required]
        public int Paper { get; set; }
        [Required]
        public double Cost { get; set; }
    }
}
