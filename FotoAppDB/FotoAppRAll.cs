using FotoAppDB;
using FotoAppDB.Repository.Single;
using System.Linq;
using System.Data.SqlClient;
using System.IO;

namespace FotoAppDBTest
{
    public sealed class FotoAppRAll
    {
        private static FotoAppRAll mInstance = new FotoAppRAll();
        public static FotoAppRAll Ins
        {
            get
            {
                return mInstance;
            }
        }
        private FotoAppRAll()
        {
            string connectionString = SeachConnectionString();
            FotoAppDbContext fotoAppDBContext = new FotoAppDbContext(connectionString);
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
        private static string SeachConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";
            string[] s = Directory.GetDirectories("../../../FotoAppDB");
            int i = 0;
            do
            {
                if (s[i].EndsWith("FotoAppDB\\DB")) connectionStringBuilder.Add("AttachDbFilename", Path.GetFullPath(s[i]) + "\\FotoApp.mdf");
                i++;
            }
            while (s[i].EndsWith("FotoAppDB\\DB") && s.Count() > i);
            return connectionStringBuilder.ConnectionString;
        }
        public void Save()
        {
            Fotos.Save();
        }

    }
}
