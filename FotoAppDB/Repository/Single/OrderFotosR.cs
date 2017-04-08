using FotoAppDB.Exception;
using FotoAppDB.DBModel;
using FotoAppDB.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FotoAppDB.Repository.Single
{
    public class OrderFotosR : FotoAppR<FotoAppDbContext, OrderFotos>, IOrderFotosR
    {
        public List<OrderFotos> AllFotosInOrder(Orders order)
        {
            return Context
                .OrderFoto
                .Where(o => o.OrderID == order.OrderID)
                .ToList();
        }

        public override OrderFotos Get(OrderFotos FAobject)
        {
            OrderFotos o = Context.OrderFoto.Find(FAobject.FotoID, FAobject.OrderID, FAobject.Height, FAobject.Length, FAobject.TypeID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono zamowienia");
            }
        }

        public override bool Is(OrderFotos FAobject)
        {
            return Context.OrderFoto.Find(FAobject.FotoID, FAobject.OrderID, FAobject.Height, FAobject.Length, FAobject.TypeID) != null;
        }
    }
}
