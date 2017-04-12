using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface ISizesR
    {
        List<Sizes> GetAll(bool available);
        List<Sizes> GetSizesByType(Types types);
        List<Sizes> GetSizesByType(Types types, bool available);
    }
}
