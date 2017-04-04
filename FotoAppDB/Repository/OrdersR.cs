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
    public class OrdersR : IRepository<Orders,int>
    {
        private readonly FotoAppDbContext context;
        public OrdersR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Orders FAobject)
        {
            context.Order.Add(FAobject);
        }

        public bool Is(Orders FAobject)
        {
            return context.Order.Find(FAobject.OrderID) != null;
        }

        public Orders Get(int id)
        {
            Orders o = context.Order.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zaneliona zamowienia");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
