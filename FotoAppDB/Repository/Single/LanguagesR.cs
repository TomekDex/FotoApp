using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoAppDB.Repository.Single
{

    public class LanguagesR : FotoAppR<FotoAppDbContext, Languages>
    {
        public override Languages Get(Languages FAobject)
        {
            Languages o = Context.Language.Find(FAobject.Language);
            if (o != null)
            {
                FAobject = o;
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
            }
        }

        public override bool Is(Languages FAobject)
        {
            return Context.Language.Find(FAobject.Language) != null;
        }
    }
}
