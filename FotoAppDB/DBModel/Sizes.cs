using FotoAppDB.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public class Sizes
    {
        [Key, Column(Order = 1)]
        public int PaperID { get; set; }
        [Key, MaxLength(5), Column(Order = 2)]
        public string Language { get; set; }
        [MaxLength(20), Required]
        public string Size { get; set; }
        public virtual Papers Papers { get; set; }
        public virtual Languages Languages { get; set; }

       
    }
}
