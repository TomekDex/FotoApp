using FotoAppDB.Repository.Interface;
using System.Data.Entity;
using System;
using System.Linq;

namespace FotoAppDB.Repository
{
    public abstract class FotoAppR<FA, T> :
        IRepository<T> where T : class where FA : DbContext, new()
    {
        private FA _fa = new FA();
        public FA Context
        {
            get { return _fa; }
            set { _fa = value; }
        }

        public void Add(T FAobject)
        {
            _fa.Set<T>().Add(FAobject);
        }

        public void AddOrUpdate(T FAobject)
        {
            if (this.Is(FAobject)) this.Update(FAobject);
            else this.Add(FAobject);
        }

        public void Delete(T FAobject)
        {
            _fa.Set<T>().Attach(FAobject);
            _fa.Set<T>().Remove(FAobject);
        }

        public abstract T Get(T FAobject);

        public IQueryable<T> GetAll()
        {
            return _fa.Set<T>();
        }

        public abstract bool Is(T FAobject);


        public void Save()
        {
            _fa.SaveChanges();
        }

        public void Update(T FAobject)
        {
            var o = this.Get(FAobject);
            _fa.Entry(o).CurrentValues.SetValues(FAobject);
        }
    }
}
