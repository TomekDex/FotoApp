using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;

namespace FotoAppDB.DBModel
{
    public class OrdersR : IRepository<Orders,int>, IOrdersR
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

        public void Update(Orders order)
        {
            context.Order.Attach(order);
            context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(Orders order)
        {

            context.Order.Attach(order);
            context.Order.Remove(order);
        }

        public float OrderValue(Orders order)
        {
          //  return 
                //(from F in context.Foto
                //   where F.OrderID == order.OrderID
                //   group F by F.PaperID into g
                //   select new {paperID = g.Key,
                //       sum = g.Sum(s=> s.Quantity)})
                   

                //    join P in context.Price 
         
                //  // group F by F.PaperID into g

                //   where g.Sum(x=> x.Quantity)<g.Max(P)
                //   select new 
                //   {
                //       g.Sum(x=>)
                //   }
                   //equals P.PaperID
        }
    }
}
