using FotoAppDB.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel 
{

    public class LanguagesR : IRepository<Languages, string>
    {        
        private readonly FotoAppDbContext context;
        public LanguagesR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Languages FAobject)
        {
            context.Language.Add(FAobject);
        }

        public bool Is(Languages FAobject)
        {
            return context.Language.Find(FAobject.Language) != null;
        }

        public Languages Get(string id)
        {
            Languages o = context.Language.Find(id);
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

        public void Update(Languages FAobject)
        {
            throw new NotImplementedException();
        }
    }
}
