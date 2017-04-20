using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FotoAppDB.Exception;

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
                return _mail;
            }
            set
            {
                if (value == null) { _mail = null; }
                else if (value.Length > maxLengthMail) { throw new OutOfMaxLengthException(); }
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
                if (value == null) { _tele = null; }
                else if (value.Length > maxLengthTele) { throw new OutOfMaxLengthException(); }
                else { _tele = value; }
            }
        }
        public Orders Orders { get; set; }


    }
}
