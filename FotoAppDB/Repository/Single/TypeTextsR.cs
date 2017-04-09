using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoAppDB.Repository.Single
{

    public class TypeTextsR : FotoAppR<FotoAppDbContext, TypeTexts>
    {
        public override TypeTexts Get(TypeTexts FAobject)
        {
            TypeTexts o = Context.TypeText.Find(FAobject.TypeID, FAobject.Language);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
            }
        }

        public override bool Is(TypeTexts FAobject)
        {
            return Context.TypeText.Find(FAobject.TypeID, FAobject.Language) != null;
        }
    }
}
