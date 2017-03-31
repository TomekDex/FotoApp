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
      //  [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaperID { get; set; }
     // [ForeignKey("Sizes"), Required, Column(Order = 1)]
        public int SizeID { get; set; }
     // [ForeignKey("Types"), Required, Column(Order = 1)]
        public int TypeID { get; set; }
      //  [Required]
        public double Cost { get; set; }
        public virtual ICollection<Sizes> Sizes { get; set; }
       // public virtual Types Types { get; set; }
        public virtual ICollection<Types> Types { get; set; }
    }
}
