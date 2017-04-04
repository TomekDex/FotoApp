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
    public class OrdersR : IRepository<Orders, int>, IOrdersR
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

        public Double OrderValue(Orders order)
        {
            // return
            //  List<Double> d =
            //    var d = 
            //    from T in
            //(from T in (
            //    (from q in (
            //        (from f in context.Foto
            //         where
            //        f.OrderID == order.OrderID
            //         group f by new
            //         {
            //             f.PaperID
            //         } into g
            //         select new
            //         {
            //             sumQ = (int?)g.Sum(p => p.Quantity),
            //             g.Key.PaperID
            //         }))
            //     join p0 in context.Price on new { PaperID = q.PaperID } equals new { PaperID = p0.PaperID }
            //     where
            //    q.sumQ > p0.Quantity
            //     group new { p0, q } by new
            //     {
            //         p0.PaperID,
            //         q.sumQ
            //     } into g
            //     select new
            //     {
            //         g.Key.PaperID,
            //         g.Key.sumQ,
            //         Qua = (int?)g.Max(p => p.p0.Quantity)
            //     }))
            // join p in context.Price
            //       on new { PaperID = T.PaperID, Quantity = Convert.ToInt32(T.Qua) }
            //   equals new { p.PaperID, p.Quantity }
            // select new
            // {
            //     Column1 = (double?)((double)T.sumQ * p.Price),
            //     Dummy = "x"
            // })
            //    group T by new { T.Dummy } into g
            //    select (double?)g.Sum(p => p.Column1);

            //return d.First<Double>();
            return 0;

        }
    }
}
