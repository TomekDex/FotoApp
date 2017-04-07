using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDB.Repository;
using FotoAppDB.Repository.Single;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FotoAppDBTest
{
   
    class Program
    {

        static void Main(string[] args)
        {
           // Console.WriteLine(new SeachConnectionString().connectionString);
            var bf = new FotoAppDbContext(new SeachConnectionString().connectionString);
            bf.Type.Add(new Types());
            bf.SaveChanges();
           // Console.WriteLine(bf.Database.Connection.ConnectionString);
            // SqlConnectionStringBuilder aaa = new SqlConnectionStringBuilder();

            // Console.WriteLine(bf.Database.Connection.ConnectionString);

            // aaa.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";
            // string[] s = Directory.GetDirectories("../../../FotoAppDB");
            // int i = 0;
            // do
            // {
            //     if (s[i].EndsWith("FotoAppDB\\DB")) aaa.Add("AttachDbFilename", Path.GetFullPath(s[i]) + "\\FotoApp.mdf");
            // }
            // while (s[i].EndsWith("FotoAppDB\\DB") && s.Count() > i);
            //             foreach (string i in Directory.GetDirectories("../../../FotoAppDB"))
            // {
            //     if (i.EndsWith("FotoAppDB\\DB")) aaa.Add("AttachDbFilename", Path.GetFullPath(i)+"\\FotoApp.mdf");
            // }
            // bf.Database.Connection.ConnectionString = aaa.ConnectionString;

            // var aaaaaa = new FotoAppDbContext(aaa.ConnectionString);
            // Console.WriteLine(bf.Database.Connection.ConnectionString);
            // //ConfigurationManager.ConnectionStrings = bf.Database.Connection.ConnectionString;
            //// AppSettings set
            // aaaaaa.Type.Add(new Types());
            // aaaaaa.SaveChanges();


            // EntityConnectionStringBuilder aa = new EntityConnectionStringBuilder();
            // ab.ConnectionString = bf.Database.Connection.ConnectionString;
            // Console.WriteLine(aa);
            // aa.Remove("AttachDbFilename");
            // Console.WriteLine(aa);
            //ab = bf.Database.Connection.ConnectionString;
            //EntityConnectionStringBuilder.AppendKeyValuePair("AttachDbFilename");

            //// bf.Type.Add(new Types());
            //// bf.SaveChanges();
            //// Console.WriteLine(bf.Database.Connection.ConnectionString);
            //Console.WriteLine("");
            //Console.WriteLine(Path.GetPathRoot(Directory.GetCurrentDirectory()));
            //Console.WriteLine( "");
            //foreach (string i in Directory.GetDirectories("../../../FotoAppDB"))
            //{
            //    if (i.EndsWith("FotoAppDB\\DB")) Console.WriteLine(Path.GetFullPath(i));

            //    aaa.Add("AttachDbFilename", Path.GetFullPath(i));
            //    Console.WriteLine("");
            //}
            //Console.WriteLine("");
            //Console.WriteLine(aaa.ConnectionString);
            //Console.WriteLine(aa);

            // Console.WriteLine(Path.GetFullPath(i));
            // var bf = new FotoAppDbContext();
            // bf.Type.Add(new Types());
            // bf.SaveChanges();
            // FotoAppR<FotoAppDbContext, Papers> r = new PapersR();
            // Console.WriteLine(   r.Get(new Papers() { SizeID = 1, TypeID =1 }).Availability.ToString());

            //  Orders o = new Orders("kakaka", new DateTime(11, 11, 11));
            ////  o.Add(bf);

            ////  Orders a = new Orders("kakcacaka", new DateTime(12, 12, 12));
            ////  a.Add(bf);

            ////  Orders b = new Orders("kakaasdka", new DateTime(10, 10, 10));
            ////  b.Add(bf);
            //Languages l = new Languages();
            //l.Language = "nowAa";
            ////Orders g = Orders.Get(bf, 2);
            ////console.writeline(g.date.tostring());
            ////Console.WriteLine(g.OrderID.ToString());
            ////Console.WriteLine(g.Description);
            ////Console.WriteLine(Languages.Is(bf, "aaaaa").ToString());
            //LanguagesR ll = new LanguagesR(bf);
            //Console.WriteLine(ll.Is(l).ToString());
            //ll.Add(l);
            //Console.WriteLine(ll.Is(l).ToString());
            //ll.Save();
            //Console.WriteLine(ll.Is(l).ToString());
            //Languages lal = ll.Get("nowA");
            //Console.WriteLine(lal.Language);
            ////  Console.WriteLine(i.ToString());
            ////IDBModel Orders = Orders.Add

            //OrdersR OR = new OrdersR(bf);
            //FotosR FR = new FotosR(bf);
            //PapersR PR = new PapersR(bf);
            //PricesR PrR = new PricesR(bf);
            //List<Fotos> f = OR.OrderFotos(new Orders() { OrderID = 4 });

            //Console.WriteLine(OR.OrderValue(new Orders() { OrderID = 4 }).ToString());

            //Console.WriteLine(f.Count.ToString());

            //foreach (Fotos i in f)
            //{
            //    Console.WriteLine(i.PaperID.ToString()+" " + i.Quantity.ToString());
            //}
            //f.Sort();
            //foreach (Fotos i in f)
            //{
            //    Console.WriteLine(i.PaperID.ToString() + " " + i.Quantity.ToString());
            //}
            //for (int i = 1; i<5; i++)
            //{
            //    for(int j =1;j<10; j++)
            //    {
            //        PrR.Add(new Prices() { Quantity = j * 100, PaperID = i, Price = j*50 });
            //    }
            //}
            //for (int i = 1; i < 5; i++)
            //{
            //    for (int j = 1; j < 10; j++)
            //    {
            //        FR.Add(new Fotos() { OrderID = 4, PaperID = i, Quantity = j * 9, Name = "a" });
            //    }
            //}
            //OR.Save();

            //Papers p = new Papers();
            //PR.Add(p);
            //Fotos f = new Fotos() { OrderID = 4, Name = "a", PaperID = p.PaperID, Quantity = 1 };
            //FR.Add(f);
            //Orders ooo = new Orders() { Description = "zamiana", OrderID = 4, Date = DateTime.Today };
            //OR.Update(ooo);
            //OR.Save();
            // OR.Delete(new Orders() { OrderID = 2 });
            //for (int i = 0; i < 10; i++)
            //{
            //    OR.Add(new Orders(i.ToString(),DateTime.Today));
            //}
            //.Delete(new Orders() {OrderID=3 });
            // OR.Save();
            Console.WriteLine("koniec");
            Console.ReadKey();
        }

    }
    
}
