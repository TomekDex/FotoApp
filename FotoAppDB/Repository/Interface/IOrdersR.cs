using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface IOrdersR
    {
        double? OrderValue(Orders order);
    }
}
