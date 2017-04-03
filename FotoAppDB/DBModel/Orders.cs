using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;

namespace FotoAppDB.DBModel
{
    public class Orders : IDBModel
    {
        private Orders() { }
        public Orders(string Description, DateTime Date)
        {
            this.Date = Date;
            this.Description = Description;
        }
        private string _description;
        public const int maxLengthDescription = 200;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; private set; }
        [MaxLength(maxLengthDescription)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value.Length > maxLengthDescription) { throw new OutOfMaxLengthException(); }
                else { _description = value; }
            }
        }
        [Required, Column(TypeName = "datetime2")]
        public DateTime Date { get; private set; }

        public void Add(FotoAppDbContext db)
        {
            db.Order.Add(this);
            db.SaveChanges();
        }
       
        public static Orders Get(FotoAppDbContext db, int id)
        {
            Orders o = db.Order.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException();
            }
        }


        public void Remove(FotoAppDbContext db)
        {
            throw new NotImplementedException();
        }

        public static bool Is(FotoAppDbContext db, int id)
        {
            return db.Order.Find(id) != null;
        }
        public bool Is(FotoAppDbContext db)
        {
            return db.Order.Find(this.OrderID) != null;
        }
    }
}
