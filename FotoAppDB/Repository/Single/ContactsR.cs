using FotoAppDB.Exception;
using FotoAppDB.DBModel;

namespace FotoAppDB.Repository.Single
{
    public class ContactsR : FotoAppR<FotoAppDbContext, Contacts>
    {
        public override Contacts Get(Contacts FAobject)
        {
            Contacts o = Context.Contact.Find(FAobject.OrderID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zdefiniowano danych kontaktowych");
            }
        }

        public override bool Is(Contacts FAobject)
        {
            return Context.Contact.Find(FAobject.OrderID) != null;
        }
    }
}
