using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class LogsR : FotoAppR<FotoAppDbContext, Logs>
    {
        public override Logs Get(Logs FAobject)
        {
            Logs o = Context.Log.Find(FAobject.Area, FAobject.Type, FAobject.LogID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zdefiniowano ustawien");
            }
        }

        public override bool Is(Logs FAobject)
        {
            return Context.Log.Find(FAobject.Area, FAobject.Type, FAobject.LogID) != null;
        }
    }
}
