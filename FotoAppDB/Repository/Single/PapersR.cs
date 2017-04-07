using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class PapersR : FotoAppR<FotoAppDbContext, Papers>
    {
        public override Papers Get(Papers FAobject)
        {
            Papers o = Context.Paper.Find(FAobject.SizeID, FAobject.TypeID);
            if (o != null)
            {
                FAobject = o;
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak informacji o rodzaju papieru!");
            }
        }

        public override bool Is(Papers FAobject)
        {
            return Context.Paper.Find(FAobject.SizeID, FAobject.TypeID) != null;
        }
    }
}
