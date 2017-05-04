using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface IOrderFotosR
    {        
        List<OrderFotos> GetAllFotosInOrder(Orders order);
        List<OrderFotos> GetFotoInOrder(Fotos foto);
    }
}
