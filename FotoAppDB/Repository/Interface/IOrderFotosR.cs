using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface IOrderFotosR
    {        
        List<OrderFotos> AllFotosInOrder(Orders order);
    }
}
