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
            //  o.Add(bf);

            //  Orders a = new Orders("kakcacaka", new DateTime(12, 12, 12));
            //  a.Add(bf);

            //  Orders b = new Orders("kakaasdka", new DateTime(10, 10, 10));
            //  b.Add(bf);
            Languages l = new Languages();
            l.Language = "nowAa";
            //Orders g = Orders.Get(bf, 2);
            //Console.WriteLine(g.Date.ToString());
            //Console.WriteLine(g.OrderID.ToString());
            //Console.WriteLine(g.Description);
            //Console.WriteLine(Languages.Is(bf, "aaaaa").ToString());
            LanguagesR ll = new LanguagesR(bf);
            Console.WriteLine(ll.Is(l).ToString());
            ll.Add(l);
            Console.WriteLine(ll.Is(l).ToString());
            ll.Save();
            Console.WriteLine(ll.Is(l).ToString());
            Languages lal = ll.Get("nowA");
            Console.WriteLine(lal.Language);
            //  Console.WriteLine(i.ToString());
            //IDBModel Orders = Orders.Add
            Console.ReadKey();
        }
    }
}
