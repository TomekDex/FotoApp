using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoAppDB.Repository.Single
{
    public class TypesR : FotoAppR<FotoAppDbContext, Types>
    {
        public override Types Get(Types FAobject)
        {
            Types o = Context.Type.Find(FAobject.TypeID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak typu!");
            }
        }

        public override bool Is(Types FAobject)
        {
            return Context.Type.Find(FAobject.TypeID) != null;
        }
    }
}
