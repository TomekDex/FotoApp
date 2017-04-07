using System.ComponentModel.DataAnnotations;

namespace FotoAppDB.DBModel
{
    public class Prices
    {
        public int SizeID { get; set; }
        public int TypeID { get; set; }
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual Papers Papers { get; set; }
    }
}
