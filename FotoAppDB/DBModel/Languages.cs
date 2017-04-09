using FotoAppDB.Exception;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FotoAppDB.DBModel
{
    public class Languages
    {
        public Languages()
        {
            this.SizeTexts = new HashSet<SizeTexts>();
            this.TypeTexts = new HashSet<TypeTexts>();
        }

        public const int maxLengthLanguage = 5;
        private string _language;

        [Key, MaxLength(maxLengthLanguage)]
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

        public virtual ICollection<SizeTexts> SizeTexts { get; set; }
        public virtual ICollection<TypeTexts> TypeTexts { get; set; }
    }
}
