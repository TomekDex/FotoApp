using FotoAppDB.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel 
{

    public class Languages : IDBModel
    {
        public Languages()
        {
            this.Sizes = new HashSet<Sizes>();
            this.Types = new HashSet<Types>();

        }

        public const int maxLengthLanguage = 5;
        private string _language;

        [Key, MaxLength(maxLengthLanguage)]
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                if (value.Length > maxLengthLanguage) { throw new OutOfMaxLengthException(); }
                else { _language = value; }
            }
        }
        public virtual ICollection<Sizes> Sizes { get; set; }
        public virtual ICollection<Types> Types { get; set; }



        public void Add(FotoAppDbContext db)
        {
            try
            {
                db.Language.Add(this);
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {//obsluga wyjatgu gdy już jest dany rekord
            }
        }

        public static Languages Get(FotoAppDbContext db, int id)
        {
            Languages o = db.Language.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak tłumaczenia!");
            }
        }

        public static bool Is(FotoAppDbContext db, string lang)
        {
            return db.Language.Find(lang) != null;
        }

        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }

        public bool Is(FotoAppDbContext db)
        {
            return db.Language.Find(this.Language) != null;
        }
    }
}
