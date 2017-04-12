using FotoAppDB.Exception;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Settings
    {
        public const int maxLengthArea = 10;
        private string _area;
        public const int maxLengthTarget = 10;
        private string _target;
        public const int maxLengthValue = 20;
        private string _value;
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
        [Key, Column(Order = 2), MaxLength(maxLengthTarget)]
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                if (value.Length > maxLengthTarget) { throw new OutOfMaxLengthException(); }
                else { _target = value; }
            }
        }
        [Required, MaxLength(maxLengthValue)]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.Length > maxLengthValue) { throw new OutOfMaxLengthException(); }
                else { _value = value; }
            }
        }
    }
}
