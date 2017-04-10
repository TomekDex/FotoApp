using System.ComponentModel.DataAnnotations;

namespace FotoAppDB.DBModel
{
    public class Prices
    {
        public int Height { get; set; }
        public int Length { get; set; }
        public int TypeID { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        public virtual Papers Papers { get; set; }
    }
}
