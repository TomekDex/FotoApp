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
    public class SizesR : IRepository<Sizes, int, string>
    {

        private readonly FotoAppDbContext context;
        public SizesR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Sizes FAobject)
        {
            context.Size.Add(FAobject);
        }

        public bool Is(Sizes FAobject)
        {
            return context.Size.Find(FAobject.PaperID, FAobject.Language) != null;
        }

        public Sizes Get(int id1, string id2)
        {
            Sizes o = context.Size.Find(id1, id2);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak rozmiaru!");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
