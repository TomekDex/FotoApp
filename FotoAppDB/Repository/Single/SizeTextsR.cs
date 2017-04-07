using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoAppDB.Repository.Single
{

    public class SizeTextsR : FotoAppR<FotoAppDbContext, SizeTexts>
    {
        public override SizeTexts Get(SizeTexts FAobject)
        {
            SizeTexts o = Context.SizeText.Find(FAobject.SizeID, FAobject.Language);
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

        public override bool Is(SizeTexts FAobject)
        {
            return Context.SizeText.Find(FAobject.SizeID, FAobject.Language) != null;
        }
    }
}
