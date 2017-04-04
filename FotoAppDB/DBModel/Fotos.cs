using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using FotoAppDB.Exception;

namespace FotoAppDB.DBModel
{
    public class Fotos
    {
        public const int maxLengthName = 50;
        private string _name;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotoID { get; private set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        [ForeignKey("Papers")]
        public int PaperID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, MaxLength(maxLengthName)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > maxLengthName) { throw new OutOfMaxLengthException(); }
                else { _name = value; }
            }
        }
        public Orders Orders { get; set; }
        public Papers Papers { get; set; }

      
    }
}
