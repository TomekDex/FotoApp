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
        public FotoAppRAll()
        {
            var bf = new FotoAppDbContext(new SeachConnectionString().connectionString);
            Types.Context = bf;
            Contacts.Context = bf;
            Languages.Context = bf;
            OrderFotos.Context = bf;
            Orders.Context = bf;
            Papers.Context = bf;
            Prices.Context = bf;
            Settings.Context = bf;
            Sizes.Context = bf;
            SizeTexts.Context = bf;
            Types.Context = bf;
            TypeTexts.Context = bf;
            Fotos.Context = bf;

        }
        public FotoAppR<FotoAppDbContext, Contacts> Contacts = new ContactsR();
        public FotoAppR<FotoAppDbContext, Languages> Languages = new LanguagesR();
        public FotoAppR<FotoAppDbContext, OrderFotos> OrderFotos = new OrderFotosR();
        public FotoAppR<FotoAppDbContext, Orders> Orders = new OrdersR();
        public FotoAppR<FotoAppDbContext, Papers> Papers = new PapersR();
        public FotoAppR<FotoAppDbContext, Prices> Prices = new PricesR();
        public FotoAppR<FotoAppDbContext, Settings> Settings = new SettingsR();
        public FotoAppR<FotoAppDbContext, Sizes> Sizes = new SizesR();
        public FotoAppR<FotoAppDbContext, SizeTexts> SizeTexts = new SizeTextsR();
        public FotoAppR<FotoAppDbContext, Types> Types = new TypesR();
        public FotoAppR<FotoAppDbContext, TypeTexts> TypeTexts = new TypeTextsR();
        public FotoAppR<FotoAppDbContext, Fotos> Fotos = new FotosR();

    }
}
