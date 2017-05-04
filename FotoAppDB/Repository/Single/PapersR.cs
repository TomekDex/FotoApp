using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class PapersR : FotoAppR<FotoAppDbContext, Papers>
    {
        public override Papers Get(Papers FAobject)
        {
            Papers o = Context.Paper.Find(FAobject.Height, FAobject.Width, FAobject.TypeID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak informacji o rodzaju papieru!");
            }
        }        

        public override bool Is(Papers FAobject)
        {
            return Context.Paper.Find(FAobject.Height, FAobject.Width, FAobject.TypeID) != null;
        }
    }
}
