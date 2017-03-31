using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Contacts
    {
        [Key, ForeignKey("Orders")]
        public int OrderID { get; set; }
        public string Mail { get; set; }
        public string TelephoneNumber { get; set; }
        public Orders Orders { get; set; }
    }
}
