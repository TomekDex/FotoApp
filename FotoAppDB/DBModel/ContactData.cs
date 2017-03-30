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
    class ContactData
    {
        //Mail i telefon nie beda przechowywane bez zamowienia
        //Wiec bez sensu chyba tworzyć nowy ID dla tej tabeli?
        //Tylko nie jestem pewna, czy zapis prawidłowy, tomek sprawdz
        //ForeignKey => OrderID jako Primary Key
        [Key, ForeignKey("OrderID")]
        public int OrderID;
        public string Mail;
        public string TelephoneNumber;
    }
}
