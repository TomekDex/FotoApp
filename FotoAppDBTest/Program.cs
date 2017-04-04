using FotoAppDB;
using FotoAppDB.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FotoAppDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var bf = new FotoAppDbContext();
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
            
            OrdersR OR = new OrdersR(bf);
            FotosR FR = new FotosR(bf);
            PapersR PR = new PapersR(bf);
            PricesR PrR = new PricesR(bf);
            Console.WriteLine( OR.OrderValue(new Orders() { OrderID = 4 }).ToString());
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
