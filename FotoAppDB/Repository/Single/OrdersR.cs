using System.Collections.Generic;
using System.Linq;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class OrdersR : FotoAppR<FotoAppDbContext, Orders>, IOrdersR
    {
        public override Orders Get(Orders FAobject)
        {
            Orders o = Context.Order.Find(FAobject.OrderID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono zamowienia");
            }
        }

        public override bool Is(Orders FAobject)
        {
            return Context.Order.Find(FAobject.OrderID) != null;
        }


        public double? OrderValue(Orders order)
        {
            //var d =
            //    (from T in
            //(from T in (
            //    (from q in (
            //            (from f in context.Foto
            //             where
            //             f.OrderID == order.OrderID
            //             group f by new
            //             {
            //                 f.PaperID
            //             } into g
            //             select new
            //             {
            //                 sumQ = (int?)g.Sum(p => p.Quantity),
            //                 g.Key.PaperID
            //             }))
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
            //       on new { PaperID = T.PaperID, Quantity = (int)T.Qua }
            //   equals new { p.PaperID, p.Quantity }
            // select new
            // {
            //     Column1 = (double?)((double)T.sumQ * p.Price),
            //     Dummy = "x"
            // })
            //     group T by new { T.Dummy } into g
            //     select new
            //     {
            //         Column1 = (double?)g.Sum(p => p.Column1)
            //     }).Single();
            //    return d.Column1;
            return null;
        }
    }
}
