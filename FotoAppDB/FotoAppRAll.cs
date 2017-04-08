using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDB.Repository;
using FotoAppDB.Repository.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDBTest
{
   public class FotoAppRAll
    {
        FotoAppDbContext fotoAppDBContext;
        public FotoAppRAll(string connectionString)
        {
            fotoAppDBContext = new FotoAppDbContext(connectionString);
            Types.Context = fotoAppDBContext;
            Contacts.Context = fotoAppDBContext;
            Languages.Context = fotoAppDBContext;
            OrderFotos.Context = fotoAppDBContext;
            Orders.Context = fotoAppDBContext;
            Papers.Context = fotoAppDBContext;
            Prices.Context = fotoAppDBContext;
            Settings.Context = fotoAppDBContext;
            Sizes.Context = fotoAppDBContext;
            SizeTexts.Context = fotoAppDBContext;
            Types.Context = fotoAppDBContext;
            TypeTexts.Context = fotoAppDBContext;
            Fotos.Context = fotoAppDBContext;

        }
        public ContactsR Contacts = new ContactsR();
        public LanguagesR Languages = new LanguagesR();
        public OrderFotosR OrderFotos = new OrderFotosR();
        public OrdersR Orders = new OrdersR();
        public PapersR Papers = new PapersR();
        public PricesR Prices = new PricesR();
        public SettingsR Settings = new SettingsR();
        public SizesR Sizes = new SizesR();
        public SizeTextsR SizeTexts = new SizeTextsR();
        public TypesR Types = new TypesR();
        public TypeTextsR TypeTexts = new TypeTextsR();
        public FotosR Fotos = new FotosR();
        public void Save()
        {
            Fotos.Save();
        }

    }
}
