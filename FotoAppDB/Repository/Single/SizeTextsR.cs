using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoAppDB.Repository.Single
{

    public class SizeTextsR : FotoAppR<FotoAppDbContext, SizeTexts>
    {
        public override SizeTexts Get(SizeTexts FAobject)
        {
            SizeTexts o = Context.SizeText.Find(FAobject.Height, FAobject.Length, FAobject.Language);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
            }
        }

        public override bool Is(SizeTexts FAobject)
        {
            return Context.SizeText.Find(FAobject.Height, FAobject.Length, FAobject.Language) != null;
        }
    }
}
