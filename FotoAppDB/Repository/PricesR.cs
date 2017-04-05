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
    public class PricesR : IRepository<Prices, int, int>
    {

        private readonly FotoAppDbContext context;
        public PricesR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Prices FAobject)
        {
            context.Price.Add(FAobject);
        }

        public bool Is(Prices FAobject)
        {
            return context.Price.Find(FAobject.PaperID, FAobject.Quantity) != null;
        }

        public Prices Get(int id1, int id2)
        {
            Prices o = context.Price.Find(id1,id2);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak ceny!");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Prices price)
        {
            context.Price.Attach(price);
            context.Entry(price).State = EntityState.Modified;
        }
    }
}
