using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Sizes
    {
        public Sizes()
        {
            this.Papers = new HashSet<Papers>();
        }        
        public int Height { get; set; }
        public int Length { get; set; }
        public virtual ICollection<Papers> Papers { get; set; }
        public virtual ICollection<SizeTexts> SizeTexts { get; set; }
    }
}
