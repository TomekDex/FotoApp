using FotoAppDB.Exception;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Languages
    {
        public Languages()
        {
            this.SizeTexts = new HashSet<SizeTexts>();
            this.TypeTexts = new HashSet<TypeTexts>();
            this.Languages1 = new HashSet<Languages>();
        }

        public const int maxLengthLanguage = 5;
        private string _language;
        private string _base;

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
        [MaxLength(maxLengthLanguage)]
        public string Base
        {
            get
            {
                return _base;
            }
            set
            {
                if (value.Length > maxLengthLanguage) { throw new OutOfMaxLengthException(); }
                else { _base = value; }
            }
        }

        public virtual ICollection<SizeTexts> SizeTexts { get; set; }
        public virtual ICollection<TypeTexts> TypeTexts { get; set; }
        public virtual ICollection<Languages> Languages1 { get; set; }
        public virtual Languages Languages2 { get; set; }

    }
}
