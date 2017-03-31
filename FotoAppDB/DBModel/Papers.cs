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
        public Papers(){
            this.Texts = new HashSet<Texts>();
}
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaperID { get; set; }
      //  [ForeignKey("Texts"), Required]
        public int Size { get; set; }
      //  [ForeignKey("TextsPaper"), Required, Display(Name = "TextsPaper"), Column(Order = 1)]
        public int Paper { get; set; }
        [Required]
        public double Cost { get; set; }
        public ICollection<Texts> Texts { get; set; }

    }
}
