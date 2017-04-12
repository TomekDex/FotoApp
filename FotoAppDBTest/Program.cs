using FotoAppDB;
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


namespace FotoAppDBTest
{

    class Program
    {

        static void Main(string[] args)
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            string a = "pl_PL";
            string b = "pl";
            string c = "pl2";
            string d = "pl3";
            string e = "pl4";
            string f = "pl5";
            all.Languages.AddOrUpdate(new Languages() { Language = a, Base = a });
            all.Languages.AddOrUpdate(new Languages() { Language = b, Base = f });
            all.Languages.AddOrUpdate(new Languages() { Language = c, Base = d });
            all.Languages.AddOrUpdate(new Languages() { Language = d, Base = c });
            all.Languages.AddOrUpdate(new Languages() { Language = e, Base = b });
            all.Languages.AddOrUpdate(new Languages() { Language = f, Base = e });
            all.Save();
            all.Languages.CheckAndFixBase();


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
            //Console.WriteLine(all.SizeTexts.GetSizeTextBySizeALang(new Sizes() { Height = 1500, Length = 21000 }, new Languages() { Language = "en" }).Text);
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
            // all.SizeTexts.GetSizeTextBySizeALang(new Sizes() { Height = 900, Length = 1300 }, new Languages() { Language = "pl" });
            //Console.WriteLine(all.Types.GetAllTypes(false).Count().ToString());
            //Console.WriteLine(all.Types.GetAllTypes(true).Count().ToString());
            //Console.WriteLine(all.Types.GetAll().Count().ToString());
            //Sizes s = new Sizes { Height = 900, Length = 1300 };
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


            #region Generator bazy danych
            //FotoAppRAll all = FotoAppRAll.Ins;
            //Sizes[] s = new Sizes[8];
            //s[0] = new Sizes() { Height = 900, Length = 1300 };
            //s[1] = new Sizes() { Height = 1000, Length = 1500 };
            //s[2] = new Sizes() { Height = 1300, Length = 1800 };
            //s[3] = new Sizes() { Height = 1500, Length = 2100 };
            //s[4] = new Sizes() { Height = 1800, Length = 2400 };
            //s[5] = new Sizes() { Height = 2000, Length = 2500 };
            //s[6] = new Sizes() { Height = 2100, Length = 3000 };
            //s[7] = new Sizes() { Height = 2400, Length = 3000 };

            //for (int i = 0; i < 8; i++)
            //{
            //    all.Sizes.AddOrUpdate(s[i]);
            //}
            //all.Contacts.Save();
            //Types[] t = new Types[4];

            //for (int i = 0; i < 4; i++)
            //{
            //    t[i] = new Types();
            //    all.Types.AddOrUpdate(t[i]);
            //    all.Contacts.Save();
            //    t[i] = new Types() {TypeID = i+1 };
            //}


            //all.Languages.AddOrUpdate(new Languages() { Language = "pl_PL" });
            //all.Languages.AddOrUpdate(new Languages() { Language = "en_EN" });
            //all.Contacts.Save();
            //SizeTexts st1 = new SizeTexts() { Height = 900, Length = 1300, Language = "pl_PL", Text = "1" }; all.SizeTexts.AddOrUpdate(st1);
            //SizeTexts st2 = new SizeTexts() { Height = 1000, Length = 1500, Language = "pl_PL", Text = "2" }; all.SizeTexts.AddOrUpdate(st2);
            //SizeTexts st3 = new SizeTexts() { Height = 1300, Length = 1800, Language = "pl_PL", Text = "3" }; all.SizeTexts.AddOrUpdate(st3);
            //SizeTexts st4 = new SizeTexts() { Height = 1500, Length = 2100, Language = "pl_PL", Text = "4" }; all.SizeTexts.AddOrUpdate(st4);
            //SizeTexts st5 = new SizeTexts() { Height = 1800, Length = 2400, Language = "pl_PL", Text = "5" }; all.SizeTexts.AddOrUpdate(st5);
            //SizeTexts st6 = new SizeTexts() { Height = 2000, Length = 2500, Language = "pl_PL", Text = "6" }; all.SizeTexts.AddOrUpdate(st6);
            //SizeTexts st7 = new SizeTexts() { Height = 2100, Length = 3000, Language = "pl_PL", Text = "7" }; all.SizeTexts.AddOrUpdate(st7);
            //SizeTexts st8 = new SizeTexts() { Height = 2400, Length = 3000, Language = "pl_PL", Text = "8" }; all.SizeTexts.AddOrUpdate(st8);
            //SizeTexts st9 = new SizeTexts() { Height = 900, Length = 1300, Language = "en_EN", Text = "1e" }; all.SizeTexts.AddOrUpdate(st9);
            //SizeTexts st10 = new SizeTexts() { Height = 1000, Length = 1500, Language = "en_EN", Text = "2e" }; all.SizeTexts.AddOrUpdate(st10);
            //all.Contacts.Save();
            //all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[0].TypeID, Text = "t1", Language = "pl_PL" });
            //all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[1].TypeID, Text = "t2", Language = "pl_PL" });
            //all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[2].TypeID, Text = "t3", Language = "pl_PL" });
            //all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[3].TypeID, Text = "t4", Language = "pl_PL" });
            //all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[1].TypeID, Text = "t1e", Language = "en_EN" });
            //Papers[] p = new Papers[20];
            //for (int i = 0; i < 8; i++)
            //{
            //    p[i] = new Papers() { TypeID = t[0].TypeID, Height = s[i].Height, Length = s[i].Length, Availability = null };
            //}
            //for (int i = 8; i < 13; i++)
            //{
            //    p[i] = new Papers() { TypeID = t[1].TypeID, Height = s[i - 8].Height, Length = s[i - 8].Length, Availability = i };
            //}
            //for (int i = 13; i < 14; i++)
            //{
            //    p[i] = new Papers() { TypeID = t[2].TypeID, Height = s[i - 13].Height, Length = s[i - 13].Length, Availability = i * 100 };
            //}
            //for (int i = 14; i < 20; i++)
            //{
            //    p[i] = new Papers() { TypeID = t[3].TypeID, Height = s[i - 14].Height, Length = s[i - 14].Length, Availability = i * 10000 };
            //}
            //all.Contacts.Save();
            //for (int i = 0; i < 20; i++) all.Papers.AddOrUpdate(p[i]);
            //for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 80 * i });
            //for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 100 * i });
            //for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 60 * i });
            //for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 40 * i });
            //all.Contacts.Save();
            //for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 70 * i });
            //for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 90 * i });
            //for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 50 * i });
            //for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 35 * i });
            //all.Contacts.Save();
            //for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 60 * i });
            //for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 80 * i });
            //for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 40 * i });
            //for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 30 * i });
            //all.Contacts.Save();
            //for (int j = 0; j < 5; j++)
            //{
            //    for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 80 * i - 5 * j });
            //    for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 75 * i - 5 * j });
            //    for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 70 * i - 5 * j });
            //    for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 50 * i - 4 * j });
            //    all.Contacts.Save();
            //}
            //Fotos[] f = new Fotos[30];
            //for (int i = 0; i < 30; i++)
            //{
            //    f[i] = new Fotos() { Name = "a" + i.ToString() };
            //    all.Fotos.Add(f[i]);
            //    all.Save();
            //    f[i] = new Fotos() { FotoID = i + 2 };

            //}
            //all.Contacts.Save();
            //Orders[] o = new Orders[8];
            //for (int i = 0; i < 8; i++)
            //{
            //    o[i] = new Orders() { OrderID = i + 2, Description = i.ToString(), Date = DateTime.Now };
            //    all.Contacts.Save();
            //    all.Orders.AddOrUpdate(o[i]);
            //    all.Contacts.AddOrUpdate(new Contacts() { OrderID = o[i].OrderID, Mail = i.ToString() + "@FotoApp.pl", TelephoneNumber = "12" + i.ToString() + i.ToString() + i.ToString() });
            //}
            //all.Contacts.Save();


            //Random rnd = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 30; j++)
            //    {
            //        for (int z = 0; z < 8; z++)
            //        {
            //            all.OrderFotos.AddOrUpdate(new OrderFotos()
            //            {
            //                FotoID = f[j].FotoID,
            //                OrderID = o[z].OrderID,
            //                Height = p[i].Height,
            //                Length = p[i].Length,
            //                TypeID = p[i].TypeID,
            //                Quantity = rnd.Next(1, 11)
            //            });
            //        }
            //        all.Contacts.Save();
            //    }
            //}
            //all.Settings.AddOrUpdate(new Settings() { Area = "lang", Target = "en", Value = "pl_PL" });
            //all.Settings.AddOrUpdate(new Settings() { Area = "acc", Target = "size", Value = "100" });
            //all.Contacts.Save();
            #endregion
            Console.WriteLine("koniec");
            Console.ReadKey();
        }

    }

}
