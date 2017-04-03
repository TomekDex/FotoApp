using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public interface IDBModel
    {
        void Add(FotoAppDbContext db);
        void Remove(FotoAppDbContext db);
        bool Is(FotoAppDbContext db);
    }
}
