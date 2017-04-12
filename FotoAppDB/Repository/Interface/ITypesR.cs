using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface ITypesR
    {
        List<Types> GetAll(bool available);
        List<Types> GetTypesBySize(Sizes size);
        List<Types> GetTypesBySize(Sizes size, bool available);
        void CheckAndFixConnect();
    }
}
