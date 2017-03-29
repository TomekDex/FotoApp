using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    class Orders
    {
        public int OrderID { get; set; }
        public double Description { get; set; }
        public DateTime Data { get; set; }
    }
}
