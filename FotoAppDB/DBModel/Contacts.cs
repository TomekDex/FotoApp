using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;
using System.Data.Entity.Infrastructure;

namespace FotoAppDB.DBModel
{
    public class Contacts 
    {
        public const int maxLengthMail = 255;
        private string _mail;
        public const int maxLengthTele = 20;
        private string _tele;
        [Key, ForeignKey("Orders")]
        public int OrderID { get; set; }
        [MaxLength(maxLengthMail)]
        public string Mail
        {
            get
            {
                return _mail ;
            }
            set
            {
                if (value.Length > maxLengthMail) { throw new OutOfMaxLengthException(); }
                else { _mail = value; }
            }
        }
        public string TelephoneNumber
        {
            get
            {
                return _tele;
            }
            set
            {
                if (value.Length > maxLengthTele) { throw new OutOfMaxLengthException(); }
                else { _tele = value; }
            }
        }
        public Orders Orders { get; set; }

        
    }
}
