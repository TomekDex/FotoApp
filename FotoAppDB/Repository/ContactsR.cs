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
    public class ContactsR : IRepository<Contacts,int>
    {
        private readonly FotoAppDbContext context;
        public ContactsR(FotoAppDbContext context)
        {
            this.context = context;
        }

        public void Add(Contacts FAobject)
        {
            context.Contact.Add(FAobject);           
        }

        public bool Is(Contacts FAobject)
        {
            return context.Contact.Find(FAobject.OrderID) != null;
        }

        public Contacts Get(int id)
        {
            Contacts o = context.Contact.Find(id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zdefiniowano danych kontaktowych");
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public void Update(Contacts contact)
        {
            context.Contact.Attach(contact);
            context.Entry(contact).State = EntityState.Modified;
        }
    }
}
