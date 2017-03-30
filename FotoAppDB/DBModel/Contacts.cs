using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotoAppDB.DBModel
{
    public class Contacts
    {
        //Mail i telefon nie beda przechowywane bez zamowienia
        //Wiec bez sensu chyba tworzyć nowy ID dla tej tabeli?
        //Tylko nie jestem pewna, czy zapis prawidłowy, tomek sprawdz
        //ForeignKey => OrderID jako Primary Key
        [Key, ForeignKey("Orders")]
        public int OrderID { get; set; }
        public string Mail { get; set; }
        public string TelephoneNumber { get; set; }
        public Orders Orders { get; set; }
    }
}
