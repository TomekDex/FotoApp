using FotoAppDB.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.Repository.Interface
{
    interface IOrdersR
    {
        void Delete(Orders order);
        float OrderValue(Orders order);
    }
}
