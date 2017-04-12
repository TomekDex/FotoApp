using FotoAppDB.Exception;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{

    public class TypeTexts
    {
        public const int maxLengthLanguage = Languages.maxLengthLanguage;
        private string _language;
        public const int maxLengthText = 20;
        private string _text;

        [Key, Column(Order = 1)]
        public int TypeID { get; set; }
        [Key, Column(Order = 2), MaxLength(maxLengthLanguage)]
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                if (value.Length > maxLengthLanguage) { throw new OutOfMaxLengthException(); }
                else { _language = value; }
            }
        }
        [Required, MaxLength(maxLengthText)]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value.Length > maxLengthText) { throw new OutOfMaxLengthException(); }
                else { _text = value; }
            }
        }

        public virtual Types Types { get; set; }
        public virtual Languages Languages { get; set; }
    }
}
