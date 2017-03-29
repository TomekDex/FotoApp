using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public class Texts
    {
        [Key]
        public int StringID;
        [Key]
        [MaxLength(5)]
        public string Language;
        [MaxLength(20)]
        public string Text;
    }
}
