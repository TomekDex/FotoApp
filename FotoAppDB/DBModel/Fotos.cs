using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;

namespace FotoAppDB.DBModel
{
    public class Fotos : IDBModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FotoID { get; private set; }
        [ForeignKey("Orders")]
        public int OrderID { get; set; }
        [ForeignKey("Papers")]
        public int PaperID { get; set; }
        [Required]
        public int Quantity { get; set; }
 //       [MaxLength(50)]
 //       public string Path { get; set; } //proponuje aby zdjecia zapisywaly sie w utawionym przez obsuge katalogu w pod katalogu z nr id zamuwienia i zdjecie o nazwie nr id zdjecia
        public Orders Orders { get; set; }
        public Papers Papers { get; set; }

        public void Add(FotoAppDbContext db)
        {
            try
            {
                db.Foto.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {//obsluga wyjatgu gdy już jest dany rekord
            }
        }

        public bool Is(FotoAppDbContext db)
        {
            return db.Foto.Find(this.FotoID) != null;
        }

        public static bool Is(FotoAppDbContext db, int id)
        {
            return db.Foto.Find(id) != null;
        }
        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }
    }
}
