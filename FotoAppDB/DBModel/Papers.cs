using System.Collections.Generic;

namespace FotoAppDB.DBModel
{
    public class Papers
    {
        public Papers()
        {
            this.Prices = new HashSet<Prices>();
            this.OrderFotos = new HashSet<OrderFotos>();
        }
        public int Height { get; set; }
        public int Length { get; set; }
        public int TypeID { get; set; }
        public int? Availability { get; set; }
        public virtual Sizes Sizes { get; set; }
        public virtual Types Types { get; set; }
        public virtual ICollection<Prices> Prices { get; set; }
        public virtual ICollection<OrderFotos> OrderFotos { get; set; }
    }
}
