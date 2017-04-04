using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;

namespace FotoAppDB.DBModel
{
    public class Orders
    {
        private string _description;
        public const int maxLengthDescription = 200;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [MaxLength(maxLengthDescription)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value.Length > maxLengthDescription) { throw new OutOfMaxLengthException(); }
                else { _description = value; }
            }
        }
        [Required, Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        
    }
}
