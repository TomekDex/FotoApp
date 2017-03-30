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
    class ContactData
    {
        [ForeignKey("OrderID")]
        public int OrderID;
        public string Mail;
        public string TelephoneNumber;
    }
}
