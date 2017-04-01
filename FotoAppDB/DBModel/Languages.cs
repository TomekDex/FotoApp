using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public class Languages
    {
        public Languages()
        {
            this.Sizes = new HashSet<Sizes>();
            this.Types = new HashSet<Types>();
        }
        [Key, MaxLength(5)]
        public string Language { get; set; }
        public virtual ICollection<Sizes> Sizes { get; set; }
        public virtual ICollection<Types> Types { get; set; }
    }
}
