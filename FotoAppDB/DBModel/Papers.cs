using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;

namespace FotoAppDB.DBModel
{
    public class Papers
    {
        public Papers()
        {
            this.Sizes = new HashSet<Sizes>();
            this.Types = new HashSet<Types>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaperID { get; set; }
        public virtual ICollection<Sizes> Sizes { get; set; }
        public virtual ICollection<Types> Types { get; set; }

        
    }
}
