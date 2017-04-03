using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Prices : IDBModel
    {
        [Key, Column(Order = 1), ForeignKey("Papers")]
        public int PaperID { get; set; }
        [Key, Column(Order = 2)]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public Papers Papers { get; set; }

        public void Add(FotoAppDbContext db)
        {
            db.Price.Add(this);
            db.SaveChanges();
        }

        public static bool Is(FotoAppDbContext db, int paperID, int quantity)
        {
            return db.Price.Find(paperID,quantity) != null;
        }
        public bool Is(FotoAppDbContext db)
        {
            return db.Price.Find(this.PaperID, this.Quantity) != null;
        }

        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }
    }
}
