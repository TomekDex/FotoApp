using FotoAppDB;
using FotoAppDB.Casing;
using FotoAppDB.DBModel;
using FotoAppDB.Repository;
using FotoAppDB.Repository.Single;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Pref.Helpers;


namespace FotoAppDBTest
{

    class Program
    {

        static void Main(string[] args)
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            // foreach (OrderFotos o in all.OrderFotos.GetFotoInOrder(new Fotos() { FotoID = 2 })) Console.WriteLine(o.Quantity.ToString());
            KeySettings s = new KeySettings();
            //s._null = new byte[] { 0x00 };
            s.BlockAll();
            s.Delete();
           // s.Delete();
            
            //foreach (OrderFotos o in all.OrderFotos.GetAllFotosInOrder(new Orders() { OrderID = 1 })) Console.WriteLine(o.FotoID.ToString());

            //foreach (Orders o in all.Orders.GetAll()) foreach (OrderRaport or in all.Orders.OrderRaport(o))
            //    {
            //        Console.WriteLine(o.OrderID + " " + or.Paper.Height/100 + "x" + or.Paper.Width/100 + " " + or.Paper.TypeID + " price " + or.Price + " " + or.Quantity );
            //    }

            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //Int64? test = 0;
            ////for (int i = 0;i<100; i++)
            //foreach (Orders o in all.Orders.GetAll())
            //    foreach (OrderRaport or in all.Orders.OrderRaport(o))
            //    {
            //         //test += or.Price;
            //        Console.WriteLine(o.OrderID + " " + or.Paper.Height / 100 + "x" + or.Paper.Width / 100 + " " + or.Paper.TypeID + " price " + or.Price + " " + or.Quantity);

            //    }

            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                   ts.Hours, ts.Minutes, ts.Seconds,
            //                                   ts.Milliseconds / 10);

            //Console.WriteLine(elapsedTime);
            //Console.WriteLine(test.ToString());

            //Stopwatch stopWatch2 = new Stopwatch();
            //stopWatch2.Start();
            //Int64? test2 = 0;
            //for (int i = 0; i < 100; i++) foreach (Orders o in all.Orders.GetAll())
            //    foreach (OrderRaport or in all.Orders.OrderRaport2(o))
            //    {
            //        test2 += or.Price;
            //        //Console.WriteLine(o.OrderID + " " + or.Paper.Height / 100 + "x" + or.Paper.Width / 100 + " " + or.Paper.TypeID + " price " + or.Price + " " + or.Quantity);

            //    }
            
            //TimeSpan ts2 = stopWatch2.Elapsed;
            //string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                   ts2.Hours, ts2.Minutes, ts2.Seconds,
            //                                   ts2.Milliseconds / 10);
            //Console.WriteLine(elapsedTime2);
            //Console.WriteLine(test2.ToString());
            // var o = new Orders() { OrderID = 2 };
            //foreach (OrderRaport or in all.Orders.OrderRaport(o)) Console.WriteLine(o.OrderID + " " + or.Paper.Height/100 + "x" + or.Paper.Width/100 + " " + or.Paper.TypeID + " price " + or.Price + " " + or.Quantity );
            //Console.WriteLine("----------------");
            //foreach (OrderRaport or in all.Orders.OrderRaport2(o)) Console.WriteLine(o.OrderID + " " + or.Paper.Height / 100 + "x" + or.Paper.Width / 100 + " " + or.Paper.TypeID + " price " + or.Price + " " + or.Quantity);


            //var order = all.Orders.Get(new Orders() { OrderID = 2 });
            //Console.WriteLine(all.Sizes.Context
            //    .OrderFoto
            //    .Where(o => o.Fotos.OrderID == order.OrderID)
            //    .Join(all.Sizes.Context.Type,
            //        a => a.TypeID,
            //        b => b.TypeID,
            //        (a, b) => new
            //        {
            //            OrderID = a.Fotos.OrderID,
            //            Height = a.Height,
            //            Width = a.Width,
            //            TypeID = a.TypeID,
            //            Quantity = a.Quantity,
            //            Connect = b.Connect
            //        })
            //    .GroupBy(a => new
            //    {
            //        OrderID = a.OrderID,
            //        Height = a.Height,
            //        Width = a.Width,
            //        Connect = ((a.Connect == null) ? a.TypeID : a.Connect)
            //    })
            //    .Select(a => new
            //    {
            //        OrderID = a.Key.OrderID,
            //        Height = a.Key.Height,
            //        Width = a.Key.Width,
            //        Connect = a.Key.Connect,
            //        TypeID = a.Min(b => b.TypeID),
            //        Sum = a.Sum(b => b.Quantity)
            //    })
            //    .Join(all.Sizes.Context.Price,
            //        a => a.Height,
            //        b => b.Height,
            //        (a, b) => new
            //        {
            //            paper = a,
            //            price = b
            //        })
            //    .Where(c =>
            //        c.paper.Connect == c.price.TypeID &&
            //        c.price.Height == c.paper.Height &&
            //        c.paper.Width == c.price.Width &&
            //        c.paper.Sum > c.price.Quantity)
            //    .GroupBy(a => new
            //    {
            //        OrderID = a.paper.OrderID,
            //        Height = a.paper.Height,
            //        Width = a.paper.Width,
            //        Sum = a.paper.Sum,
            //        Connect = a.price.TypeID,
            //        TypeID = a.paper.TypeID
            //    })
            //    .Select(a => new
            //    {
            //        OrderID = a.Key.OrderID,
            //        Height = a.Key.Height,
            //        Width = a.Key.Width,
            //        Sum = a.Key.Sum,
            //        Connect = a.Key.Connect,
            //        TypeID = a.Key.TypeID,
            //        Quantity = a.Max(b => b.price.Quantity)
            //    })
            //    .Join(all.Sizes.Context.Price,
            //        a => a.Height,
            //        b => b.Height,
            //        (a, b) => new
            //        {
            //            paper = a,
            //            price = b
            //        })
            //    .Where(c =>
            //        c.paper.Connect == c.price.TypeID &&
            //        c.price.Height == c.paper.Height &&
            //        c.paper.Width == c.price.Width &&
            //        c.paper.Quantity == c.price.Quantity)
            //    .Select(a => new
            //    {
            //        OrderID = a.paper.OrderID,
            //        TypeID = a.paper.TypeID,
            //        Connect = a.paper.Connect,
            //        Height = a.paper.Height,
            //        Width = a.paper.Width,
            //        Price = a.price.Price
            //    })
            //    .Join(all.Sizes.Context.OrderFoto,
            //        a => a.OrderID,
            //        b => b.Fotos.OrderID,
            //        (a, b) => new
            //        {
            //            cost = a,
            //            fotos = b
            //        })
            //    .Where(a =>
            //        a.fotos.Fotos.OrderID == a.cost.OrderID &&
            //        a.fotos.Height == a.cost.Height &&
            //        a.fotos.Width == a.cost.Width &&
            //        (a.cost.Connect == a.fotos.TypeID ||
            //        a.cost.TypeID == a.fotos.TypeID))
            //    .GroupBy(a => new
            //    {
            //        Height = a.fotos.Height,
            //        Width = a.fotos.Width,
            //        TypeID = a.fotos.TypeID,
            //        Price = a.cost.Price,
            //        Connect = a.cost.Connect
            //    })
            //    .Select(a => new
            //    {
            //        Height = a.Key.Height,
            //        Width = a.Key.Width,
            //        TypeID = a.Key.TypeID,
            //        Price = (Int64)a.Sum(z => z.fotos.Quantity) * (Int64)a.Key.Price,
            //        Connect = a.Key.Connect,
            //        Quantity = a.Sum(z => z.fotos.Quantity)
            //    }).ToString());
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine("-------------------------------------");
            //Console.WriteLine(all.Sizes.Context.OrderFoto.Where(o => o.Fotos.OrderID == order.OrderID).Select(a => new
            //{
            //    OrderID = order.OrderID,
            //    Height = a.Height,
            //    Width = a.Width,
            //    TypeID = a.TypeID,
            //    Quantity = a.Quantity,
            //    Connect = (a.Papers.Types.Connect == null) ? a.TypeID : a.Papers.Types.Connect,

            //}).GroupBy(a => new
            //{
            //    OrderID = a.OrderID,
            //    Height = a.Height,
            //    Width = a.Width,
            //    TypeID = a.TypeID,
            //    Connect = a.Connect,
            //    // SPrice = a.SPrice
            //}
            //    ).Select(a => new
            //    {
            //        OrderID = a.Key.OrderID,
            //        Height = a.Key.Height,
            //        Width = a.Key.Width,
            //        Connect = a.Key.Connect,
            //        TypeID = a.Key.TypeID,
            //        SumSingle = a.Sum(b => b.Quantity),
            //        // SPrice = a.Key.SPrice,

            //        //Price = a.Key.
            //    }).GroupBy(a => new
            //    {
            //        OrderID = a.OrderID,
            //        Height = a.Height,
            //        Width = a.Width,
            //        //TypeID = a.TypeID,
            //        Connect = a.Connect,
            //        //SPrice = a.SPrice
            //    }).Select(a => new
            //    {
            //        OrderID = a.Key.OrderID,
            //        Height = a.Key.Height,
            //        Width = a.Key.Width,
            //        Connect = a.Key.Connect,
            //        TypeID = a.Min(b => b.TypeID),
            //        SumSingle = a.Min(b => b.SumSingle),
            //        //Sum = a.Sum(b => b.SumSingle),   
            //        Cost = (Int64)a.Min(b => b.SumSingle) * (Int64)(all.Sizes.Context.Price.Where(d => d.Height == a.Key.Height && d.Width == a.Key.Width && d.TypeID == a.Key.Connect && d.Quantity >= a.Min(b => b.SumSingle)).OrderBy(g=>g.Quantity).FirstOrDefault().Price)
            //    })
            //.ToString());












            //foreach(OrderFotos o in all.OrderFotos.AllFotosInOrder(new Orders() {OrderID = 1 }))
            //Console.WriteLine(o.Quantity.ToString());

            //System.Console.WriteLine(all.Sizes.Context.OrderFoto.Where(a => a.Fotos.OrderID == 1));


            //foreach (Fotos f in all.Fotos.GetAll())
            //{
            //    Console.WriteLine( all.Fotos.SumFoto(f)+ " " + f.FotoID.ToString());
            //}
            //            Orders nowy = new Orders();
            //            all.Orders.Add(nowy );
            //            all.Save();
            //            Console.WriteLine( nowy.OrderID.ToString());
            //            nowy.Description = "jakis napis";
            //            nowy.Date = DateTime.Now;
            //all.Orders.Update(nowy);
            //            all.Save();
            //            Console.WriteLine(nowy.Date.ToString());
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //for (int i = 0; i < 100; i++)
            //    foreach (Orders o in all.Orders.Context.Order)
            //    {
            //        //Console.WriteLine("zamownie nr " + o.OrderID.ToString());
            //        foreach (PaperQuantity q in all.Papers.SumPapersInOrder3(o))
            //        {
            //            //Console.WriteLine("rozmiar " + (q.Paper.Height / 100).ToString() + "x" + (q.Paper.Width / 100).ToString() + " typu " + q.Paper.TypeID.ToString() + " ilosc: " + q.Quantity.ToString());
            //        }
            //    }
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                   ts.Hours, ts.Minutes, ts.Seconds,
            //                                   ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);
            //Stopwatch stopWatch1 = new Stopwatch();
            //stopWatch1.Start();
            //for (int i = 0; i < 100; i++)
            //    foreach (Orders o in all.Orders.Context.Order)
            //    {
            //        //Console.WriteLine("zamownie nr " + o.OrderID.ToString());
            //        foreach (PaperQuantity q in all.Papers.SumPapersInOrder2(o))
            //        {
            //            //Console.WriteLine("rozmiar " + (q.Paper.Height / 100).ToString() + "x" + (q.Paper.Width / 100).ToString() + " typu " + q.Paper.TypeID.ToString() + " ilosc: " + q.Quantity.ToString());
            //        }
            //    }
            //TimeSpan ts1 = stopWatch1.Elapsed;

            //string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                   ts1.Hours, ts1.Minutes, ts1.Seconds,
            //                                   ts1.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime1);
            ////Console.WriteLine(all.Contacts.Context.Database.Connection.ConnectionString);
            ////Console.WriteLine(all.Fotos.Context.Foto.First().FotoID.ToString());
            //Stopwatch stopWatch2 = new Stopwatch();
            //stopWatch2.Start();
            ////for (int i= 0; i<100;i++)
            //all.Types.Update(new Types() { TypeID = 1, Connect = 4 });
            //all.Save();
            //foreach (Orders o in all.Orders.Context.Order)
            //{
            //    Console.WriteLine("zamownie nr " + o.OrderID.ToString());
            //    foreach (OrderRaport q in all.Orders.OrderRaport(o))
            //    {
            //        Console.WriteLine("rozmiar " + (q.Paper.Height / 100).ToString() + "x" + (q.Paper.Width / 100).ToString() + " typu " + q.Paper.TypeID.ToString() + " ilosc: " + q.Quantity.ToString() + " cena z typu: " +q.Connect.ToString()+ " koszt "+q.Price.ToString()+ " cena za sztuke " +(q.Price/q.Quantity).ToString());
            //    }
            //}
            //TimeSpan ts2 = stopWatch2.Elapsed;

            // string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                    ts2.Hours, ts2.Minutes, ts2.Seconds,
            //                                    ts2.Milliseconds / 10);
            // Console.WriteLine("RunTime " + elapsedTime2);


            // Console.WriteLine(all.Sizes.Context
            //        .OrderFoto
            //        .Where(o => o.OrderID == 1)
            //        .GroupBy(a => new { Height = a.Height, Width = a.Width, TypeID = a.TypeID })
            //        .Join(all.Sizes.Context.Paper, s => new { s.Key.Height, s.Key.Width, s.Key.TypeID }, b => new { b.Height, b.Width, b.TypeID }, (s, b) => new { first = s, paper = b })
            //        .Select(a => new PaperQuantity { Paper = a.paper, Quantity = a.first.Sum(z => z.Quantity) }));


            //string a = "pl_PL";
            //string b = "pl";
            //string c = "pl2";
            //string d = "pl3";
            //string e = "pl4";
            //string f = "pl5";
            //all.Languages.AddOrUpdate(new Languages() { Language = a, Base = a });
            //all.Languages.AddOrUpdate(new Languages() { Language = b, Base = f });
            //all.Languages.AddOrUpdate(new Languages() { Language = c, Base = d });
            //all.Languages.AddOrUpdate(new Languages() { Language = d, Base = c });
            //all.Languages.AddOrUpdate(new Languages() { Language = e, Base = b });
            //all.Languages.AddOrUpdate(new Languages() { Language = f, Base = e });
            //all.Save();
            //all.Languages.CheckAndFixBase();


            //var bf = new FotoAppDbContext(new SeachConnectionString().connectionString);
            ////bf.Language.Add(new Languages() { Language = "eneea" });
            ////bf.SaveChanges();
            //var aa = bf.Language.First();
            //Console.WriteLine(aa.Language.ToString());
            // bf.Language.First();

            //string aaa = "eneee";

            // aa = bf.Language.Find(aaa);
            // Languages aaa = FotoAppRAll.Ins.Languages.Get(new Languages() { Language = "en" });



            //Console.WriteLine(   FotoAppRAll.Ins.Languages.Is(new Languages() { Language = "en"}).ToString());
            //Console.WriteLine(FotoAppRAll.Ins.Types.Is(new Types() { TypeID = 1 }).ToString());
            // FotoAppRAll.Ins.Orders.Add(new Orders());
            //FotoAppRAll.Ins.Save();
            //FotoAppRAll.Ins.Languages.CheckAndFixBase();

            // var bf = new FotoAppDbContext(new SeachConnectionString().connectionString);
            //bf.Type.AddOrUpdate(new Types());
            // bf.SaveChanges();

            //all.Sizes.
            //var a = all.Types.GetAllTypes(true);
            //foreach (Types aa in a) Console.WriteLine(aa.TypeID.ToString());
            //Console.WriteLine(all.SizeTexts.GetSizeTextBySizeALang(new Sizes() { Height = 1500, Width = 21000 }, new Languages() { Language = "en" }).Text);
            //all.Settings.AddOrUpdate();
            //Settings s = new Settings() { Area = "lang", Target = "pl_en", Value = "pl_PL" };
            ////s.Value += "aaa";
            //Console.WriteLine(s.Value);
            //all.Settings.Add(s);
            //s.Value += "error";
            //FotoAppRAll.Ins.Settings.CheckLangSettings();
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 1, Connect = 1 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 2, Connect = 7 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 3, Connect = 2 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 4, Connect = 3 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 5, Connect = 4 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 6, Connect = 5 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 7, Connect = 2 });
            //FotoAppRAll.Ins.Types.Update(new Types() { TypeID = 8, Connect = 9 });
            //FotoAppRAll.Ins.Save();
            //FotoAppRAll.Ins.Types.CheckAndFixConnect();
            //Console.WriteLine(s.Value);

            //all.Settings.Update(s);
            //all.Save();

            //Console.WriteLine(s.Value);


            //all.Settings.CheckLangSettings();
            //all.Save();
            //all.Settings.CheckLangSettings();
            // all.SizeTexts.GetSizeTextBySizeALang(new Sizes() { Height = 900, Width = 1300 }, new Languages() { Language = "pl" });
            //Console.WriteLine(all.Types.GetAllTypes(false).Count().ToString());
            //Console.WriteLine(all.Types.GetAllTypes(true).Count().ToString());
            //Console.WriteLine(all.Types.GetAll().Count().ToString());
            //Sizes s = new Sizes { Height = 900, Width = 1300 };
            //Console.WriteLine(all.Types.GetTypesBySize(s).Count().ToString());
            //Console.WriteLine(all.Types.GetTypesBySize(s,true).Count().ToString());
            //Console.WriteLine(all.Types.GetTypesBySize(s, false).Count().ToString());
            //Stopwatch stopWatch = new Stopwatch();

            //FotoAppR<FotoAppDbContext, Types> t = new TypesR();
            //t.Context = new FotoAppDbContext(new SeachConnectionString().connectionString);


            //Stopwatch stopWatch2 = new Stopwatch();
            //stopWatch2.Start();
            //for (int i = 0; i < 5000; i++)
            //{
            //    t.Add(new Types());
            //    t.Save();
            //}
            //TimeSpan ts2 = stopWatch2.Elapsed;

            //string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                   ts2.Hours, ts2.Minutes, ts2.Seconds,
            //                                   ts2.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime2);

            //// Console.WriteLine(new SeachConnectionString().connectionString);
            //var bf = new FotoAppDbContext(new SeachConnectionString().connectionString);
            ////bf.Type.AddOrUpdate(new Types());
            //// bf.SaveChanges();
            //FotoAppRAll all = new FotoAppRAll();
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //for (int i = 0; i < 5000; i++)
            //{
            //    all.Types.Add(new Types());
            //    all.Save();
            //}
            //TimeSpan ts = stopWatch.Elapsed;

            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                   ts.Hours, ts.Minutes, ts.Seconds,
            //                                   ts.Milliseconds / 10);
            //Console.WriteLine("RunTime " + elapsedTime);



            Console.WriteLine("koniec");
            Console.ReadKey();
        }

    }

}
