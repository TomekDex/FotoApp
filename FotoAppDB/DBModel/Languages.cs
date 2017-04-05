using FotoAppDB.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel 
{

    public class Languages
    {
        public Languages()
        {
            this.Sizes = new HashSet<Sizes>();
            this.Types = new HashSet<Types>();

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
        public virtual ICollection<Sizes> Sizes { get; set; }
        public virtual ICollection<Types> Types { get; set; }



       
    }
}
