using FotoAppDB.Casing;
using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface IOrdersR
    {
        List<OrderRaport> OrderRaport(Orders order);
    }
}
