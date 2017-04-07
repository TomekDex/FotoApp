using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class OrderFotosR : FotoAppR<FotoAppDbContext, OrderFotos>
    {
        public override OrderFotos Get(OrderFotos FAobject)
        {
            OrderFotos o = Context.OrderFoto.Find(FAobject.FotoID, FAobject.OrderID, FAobject.SizeID, FAobject.TypeID);
            if (o != null)
            {
                FAobject = o;
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono zamowienia");
            }
        }

        public override bool Is(OrderFotos FAobject)
        {
            return Context.OrderFoto.Find(FAobject.FotoID, FAobject.OrderID, FAobject.SizeID, FAobject.TypeID) != null;
        }
    }
}
