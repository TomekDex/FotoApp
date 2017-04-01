using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FotoAppDB.DBModel
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
