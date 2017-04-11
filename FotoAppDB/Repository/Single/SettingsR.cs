using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class SettingsR : FotoAppR<FotoAppDbContext, Settings>
    {
        public override Settings Get(Settings FAobject)
        {
            Settings o = Context.Setting.Find(FAobject.Area, FAobject.Target);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zdefiniowano ustawien");
            }
        }

        public override bool Is(Settings FAobject)
        {
            return Context.Setting.Find(FAobject.Area, FAobject.Target) != null;
        }
    }
}
