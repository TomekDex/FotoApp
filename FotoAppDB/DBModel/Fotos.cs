using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;

namespace FotoAppDB.DBModel
{
    public class Fotos
    {
        public Fotos()
        {
            this.OrderFotos = new HashSet<OrderFotos>();
        }
        public const int maxLengthName = 50;
        private string _name;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotoID { get; set; }
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

        public virtual ICollection<OrderFotos> OrderFotos { get; set; }
    }
}
