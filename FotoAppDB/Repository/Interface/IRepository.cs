namespace FotoAppDB.Repository.Interface
{
    public interface IRepository<T>
    {
        void Add(T FAobject);
        bool Is(T FAobject);
        void Save();
        void Update(T FAobject);
        void AddOrUpdate(T FAobject);
        void Delete(T FAobject);
    }
}
