using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    public interface IRepository<T>
    {
        void Add(T FAobject);
        bool Is(T FAobject);
        void Save();
    }
    public interface IRepository<T, ID> : IRepository<T>
    {
        T Get(ID id);
    }
    public interface IRepository<T, ID1, ID2> : IRepository<T>
    {
        T Get(ID1 id1, ID2 id2);
    }
}
