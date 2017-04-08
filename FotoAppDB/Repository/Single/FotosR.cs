using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class FotosR : FotoAppR<FotoAppDbContext, Fotos>
    {
        public override Fotos Get(Fotos FAobject)
        {
            Fotos o = Context.Foto.Find(FAobject.FotoID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak zdjęcia!");
            }
        }

        public override bool Is(Fotos FAobject)
        {
            return Context.Foto.Find(FAobject.FotoID) != null;
        }
    }
}
