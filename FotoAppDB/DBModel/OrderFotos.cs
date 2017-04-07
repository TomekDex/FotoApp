using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class OrderFotos
    {
        public int FotoID { get; set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        public int SizeID { get; set; }
        public int TypeID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Papers Papers { get; set; }
        public virtual Fotos Fotos { get; set; }
    }
}
