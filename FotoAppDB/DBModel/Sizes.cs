using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public class Sizes : IDBModel
    {
        [Key, Column(Order = 1)]
        public int PaperID { get; set; }
        [Key, MaxLength(5), Column(Order = 2)]
        public string Language { get; set; }
        [MaxLength(20), Required]
        public string Size { get; set; }
        public virtual Papers Papers { get; set; }
        public virtual Languages Languages { get; set; }

        public void Add(FotoAppDbContext db)
        {
            db.Size.Add(this);
            db.SaveChanges();
        }

        public static bool Is(FotoAppDbContext db, int paperID, string language)
        {
            return db.Size.Find(paperID, language) != null;
        }

        public bool Is(FotoAppDbContext db)
        {
            return db.Size.Find(this.PaperID, this.Language) != null;
        }

        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }
    }
}
