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

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeID { get; set; }
        [Required]
        public float height { get; set; }
        [Required]
        public float length { get; set; }
        public virtual ICollection<Papers> Papers { get; set; }
        public virtual ICollection<SizeTexts> SizeTexts { get; set; }
    }
}
