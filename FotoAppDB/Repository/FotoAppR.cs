using FotoAppDB.Repository.Interface;
using System.Data.Entity;

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

        public abstract bool Is(T FAobject);


        public void Save()
        {
            _fa.SaveChanges();
        }

        public void Update(T FAobject)
        {
            _fa.Set<T>().Attach(FAobject);
            _fa.Entry(FAobject).State = EntityState.Modified;
        }
    }
}
