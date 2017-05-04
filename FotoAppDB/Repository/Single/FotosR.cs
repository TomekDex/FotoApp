using FotoAppDB.Exception;
using FotoAppDB.DBModel;
using FotoAppDB.Repository.Interface;
using System;
using System.Linq;

namespace FotoAppDB.Repository.Single
{
    public class FotosR : FotoAppR<FotoAppDbContext, Fotos>, IFotosR
    {
        public int SumFoto(Fotos foto)
        {
            var sum = Context
                .OrderFoto
                .Where(a => a.FotoID == foto.FotoID)
                .GroupBy(d => new { d.FotoID })
                .Select(c => new { sum = c.Sum(a => a.Quantity) })
                .SingleOrDefault();            
            return (sum == null) ? 0 : sum.sum;
        }

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
