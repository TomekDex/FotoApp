using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;

namespace FotoAppDB.DBModel
{
    public class FotosR : IRepository<Fotos, int>, IFotosR
    {
        private readonly FotoAppDbContext context;
        public FotosR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Fotos FAobject)
        {
            context.Foto.Add(FAobject);
        }

        public bool Is(Fotos FAobject)
        {
            return context.Foto.Find(FAobject.FotoID) != null;
        }

        public Fotos Get(int id)
        {
            Fotos o = context.Foto.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak zdjęcia!");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Fotos foto)
        {
            context.Foto.Attach(foto);
            context.Entry(foto).State = EntityState.Modified;
        }

        public void Delete(Fotos foto)
        {
            context.Foto.Attach(foto);
            context.Foto.Remove(foto);
        }
    }
}
