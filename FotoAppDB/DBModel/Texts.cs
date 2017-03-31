using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public class Texts
    {
        public Texts()
        {
            this.Papers = new HashSet<Papers>();
        }

        [Key, Column(Order = 1)]
        public int TextID { get; set; }
        [Key, MaxLength(5), Column(Order = 2)]
        public string Language { get; set; }
        [MaxLength(20), Required]
        public string Text { get; set; }
        public ICollection<Papers> Papers { get; set; }
    }
}
