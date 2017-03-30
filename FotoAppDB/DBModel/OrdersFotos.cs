using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FotoAppDB.DBModel
{
    public class OrdersFotos
    {
        [Key]
        public int OrderID { get; set; }
        [Key]
        public int FotoID { get; set; }
    }
}
