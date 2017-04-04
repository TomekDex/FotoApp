using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;
using System.Data.Entity.Infrastructure;

namespace FotoAppDB.DBModel
{
    public class Contacts : IDBModel
    {
        public const int maxLengthMail = 255;
        private string _mail;
        public const int maxLengthTele = 20;
        private string _tele;
        [Key, ForeignKey("Orders")]
        public int OrderID { get; set; }
        [MaxLength(maxLengthMail)]
        public string Mail
        {
            get
            {
                return _mail ;
            }
            set
            {
                if (value.Length > maxLengthMail) { throw new OutOfMaxLengthException(); }
                else { _mail = value; }
            }
        }
        public string TelephoneNumber
        {
            get
            {
                return _tele;
            }
            set
            {
                if (value.Length > maxLengthTele) { throw new OutOfMaxLengthException(); }
                else { _tele = value; }
            }
        }
        public Orders Orders { get; set; }

        public void Add(FotoAppDbContext db)
        {
            try
            {
                db.Contact.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {//obsluga wyjatgu gdy już jest dany rekord
            }
        }

        public static Contacts Get(FotoAppDbContext db, int id)
        {
            Contacts o = db.Contact.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zdefiniowano danych kontaktowych");
            }
        }

        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }

        public static bool Is(FotoAppDbContext db, int id)
        {
            return db.Contact.Find(id) != null;
        }
        public bool Is(FotoAppDbContext db)
        {
            return db.Contact.Find(this.OrderID) != null;
        }
    }
}
