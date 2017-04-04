using FotoAppDB.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public class TypesR : IRepository<Types, int, string>
    {

        private readonly FotoAppDbContext context;
        public TypesR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Types FAobject)
        {
            context.Type.Add(FAobject);
        }

        public bool Is(Types FAobject)
        {
            return context.Type.Find(FAobject.PaperID, FAobject.Language) != null;
        }

        public Types Get(int id1, string id2)
        {
            Types o = context.Type.Find(id1, id2);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak typu!");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
