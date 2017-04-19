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
            this.Types1 = new HashSet<Types>();
            this.TypeTexts = new HashSet<TypeTexts>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeID { get; set; }
        public int? Connect { get; set; }
        public virtual ICollection<Papers> Papers { get; set; }
        public virtual ICollection<TypeTexts> TypeTexts { get; set; }
        public virtual ICollection<Types> Types1 { get; set; }
        public virtual Types Types2 { get; set; }
    }
}
