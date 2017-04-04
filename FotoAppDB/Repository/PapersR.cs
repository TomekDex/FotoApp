using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;

namespace FotoAppDB.DBModel
{
    public class PapersR : IRepository<Papers, int>
    {

        private readonly FotoAppDbContext context;
        public PapersR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Papers FAobject)
        {
            context.Paper.Add(FAobject);
        }

        public bool Is(Papers FAobject)
        {
            return context.Paper.Find(FAobject.PaperID) != null;
        }

        public Papers Get(int id)
        {
            Papers o = context.Paper.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak informacji o rodzaju papieru!");
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Papers FAobject)
        {
            throw new NotImplementedException();
        }
    }
}
