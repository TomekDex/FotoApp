using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Types
    {

        public Types()
        {
            this.Papers = new HashSet<Papers>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeID { get; set; }
        public virtual ICollection<Papers> Papers { get; set; }
        public virtual ICollection<TypeTexts> TypeTexts { get; set; }

    }
}
