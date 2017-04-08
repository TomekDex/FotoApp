using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class OrderFotosR : FotoAppR<FotoAppDbContext, OrderFotos>
    {
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
