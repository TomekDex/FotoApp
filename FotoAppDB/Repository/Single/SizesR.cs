using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoAppDB.Repository.Single
{
    public class SizesR : FotoAppR<FotoAppDbContext, Sizes>
    {
        public override Sizes Get(Sizes FAobject)
        {
            Sizes o = Context.Size.Find(FAobject.Height, FAobject.Length);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak rozmiaru!");
            }
        }

        public override bool Is(Sizes FAobject)
        {
            return Context.Size.Find(FAobject.Height, FAobject.Length) != null;
        }
    }
}
