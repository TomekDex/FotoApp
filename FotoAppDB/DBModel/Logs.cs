using FotoAppDB.Exception;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Logs
    {
        public const int maxLengthArea = 10;
        private string _area;
        public const int maxLengthType = 10;
        private string _type;
        public const int maxLengthMessage = 200;
        private string _message;
        [Key, Column(Order = 1), MaxLength(maxLengthArea)]
        public string Area
        {
            get
            {
                return _area;
            }
            set
            {
                if (value.Length > maxLengthArea) { throw new OutOfMaxLengthException(); }
                else { _area = value; }
            }
        }
        [Key, Column(Order = 2), MaxLength(maxLengthType)]
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value.Length > maxLengthType) { throw new OutOfMaxLengthException(); }
                else { _type = value; }
            }
        }
        [Key, Column(Order = 3), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }
        [Required, Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [Required, MaxLength(maxLengthMessage)]
        public string Value
        {
            get
            {
                return _message;
            }
            set
            {
                if (value.Length > maxLengthMessage) { throw new OutOfMaxLengthException(); }
                else { _message = value; }
            }
        }
    }
}
