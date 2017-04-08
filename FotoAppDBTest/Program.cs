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
            //bf.Type.AddOrUpdate(new Types());
            // bf.SaveChanges();
            FotoAppRAll all = new FotoAppRAll();
           // //all.Types.Context = bf;
           // //all.Types.AddOrUpdate(new Types());
           // Sizes[] s = new Sizes[8];
           // s[0] = new Sizes() { Height = 900, Length = 1300 };
           // s[1] = new Sizes() { Height = 1000, Length = 1500 };
           // s[2] = new Sizes() { Height = 1300, Length = 1800 };
           // s[3] = new Sizes() { Height = 1500, Length = 2100 };
           // s[4] = new Sizes() { Height = 1800, Length = 2400 };
           // s[5] = new Sizes() { Height = 2000, Length = 2500 };
           // s[6] = new Sizes() { Height = 2100, Length = 3000 };
           // s[7] = new Sizes() { Height = 2400, Length = 3000 };

           // //for (int i = 0; i < 8; i++)
           // //{
           // //    all.Sizes.AddOrUpdate(s[i]);
           // //}
           // all.Contacts.Save();
           // Types[] t = new Types[4];
           // t[0] = new Types() {TypeID =1 }; 
           // t[1] = new Types() { TypeID = 2 }; 
           // t[2] = new Types() { TypeID = 3 };
           // t[3] = new Types() { TypeID = 4 };
           // //all.Languages.AddOrUpdate(new Languages() { Language = "pl_PL" });
           // //all.Languages.AddOrUpdate(new Languages() { Language = "en" });
           // //all.Contacts.Save();
           // //SizeTexts st1 = new SizeTexts() { Height = 900, Length = 1300, Language = "pl_PL", Text = "1" }; all.SizeTexts.AddOrUpdate(st1);
           // //SizeTexts st2 = new SizeTexts() { Height = 1000, Length = 1500, Language = "pl_PL", Text = "2" }; all.SizeTexts.AddOrUpdate(st2);
           // //SizeTexts st3 = new SizeTexts() { Height = 1300, Length = 1800, Language = "pl_PL", Text = "3" }; all.SizeTexts.AddOrUpdate(st3);
           // //SizeTexts st4 = new SizeTexts() { Height = 1500, Length = 2100, Language = "pl_PL", Text = "4" }; all.SizeTexts.AddOrUpdate(st4);
           // //SizeTexts st5 = new SizeTexts() { Height = 1800, Length = 2400, Language = "pl_PL", Text = "5" }; all.SizeTexts.AddOrUpdate(st5);
           // //SizeTexts st6 = new SizeTexts() { Height = 2000, Length = 2500, Language = "pl_PL", Text = "6" }; all.SizeTexts.AddOrUpdate(st6);
           // //SizeTexts st7 = new SizeTexts() { Height = 2100, Length = 3000, Language = "pl_PL", Text = "7" }; all.SizeTexts.AddOrUpdate(st7);
           // //SizeTexts st8 = new SizeTexts() { Height = 2400, Length = 3000, Language = "pl_PL", Text = "8" }; all.SizeTexts.AddOrUpdate(st8);
           // SizeTexts st9 = new SizeTexts() { Height = 900, Length = 1300, Language = "en", Text = "1e" }; all.SizeTexts.AddOrUpdate(st9);
           // SizeTexts st10 = new SizeTexts() { Height = 1000, Length = 1500, Language = "en", Text = "2e" }; all.SizeTexts.AddOrUpdate(st10);
           // all.Contacts.Save();
           //// all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[0].TypeID, Text = "t1", Language = "pl_PL" });
           //// all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[1].TypeID, Text = "t2", Language = "pl_PL" });
           ////all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[2].TypeID, Text = "t3", Language = "pl_PL" });
           //// all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[3].TypeID, Text = "t4", Language = "pl_PL" });
           //// all.TypeTexts.AddOrUpdate(new TypeTexts() { TypeID = t[1].TypeID, Text = "t1e", Language = "en" });
           // Papers[] p = new Papers[20];
           // for (int i = 0; i < 8; i++)
           // {
           //     p[i] = new Papers() { TypeID = t[0].TypeID, Height = s[i].Height, Length = s[i].Length, Availability = null };
           // }
           // for (int i = 8; i < 13; i++)
           // {
           //     p[i] = new Papers() { TypeID = t[1].TypeID, Height = s[i - 8].Height, Length = s[i - 8].Length, Availability = i };
           // }
           // for (int i = 13; i < 14; i++)
           // {
           //     p[i] = new Papers() { TypeID = t[2].TypeID, Height = s[i - 12].Height, Length = s[i - 12].Length, Availability = i * 100 };
           // }
           // for (int i = 14; i < 20; i++)
           // {
           //     p[i] = new Papers() { TypeID = t[3].TypeID, Height = s[i - 14].Height, Length = s[i - 14].Length, Availability = i * 10000 };
           // }
           // all.Contacts.Save();
           // //for (int i = 0; i < 20; i++) all.Papers.AddOrUpdate(p[i]);
           // //for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 80 * i });
           // //for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 100 * i });
           // //for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 60 * i });
           // //for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 1, Price = 40 * i });
           // //all.Contacts.Save();
           // //for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 70 * i });
           // //for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 90 * i });
           // //for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 50 * i });
           // //for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 11, Price = 35 * i });

           // //for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 60 * i });
           // //for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 80 * i });
           // //for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 40 * i });
           // //for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 51, Price = 30 * i });
           // //all.Contacts.Save();
           // //for (int j = 0; j < 5; j++)
           // //{
           // //    for (int i = 0; i < 8; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 55 * i - 5 * j });
           // //    for (int i = 8; i < 13; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 75 * i - 5 * j });
           // //    for (int i = 13; i < 14; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 35 * i - 5 * j });
           // //    for (int i = 14; i < 20; i++) all.Prices.AddOrUpdate(new Prices() { Height = p[i].Height, Length = p[i].Length, TypeID = p[i].TypeID, Quantity = 101 + 100 * j, Price = 21 * i - 4 * j });
           // //}
           // Fotos[] f = new Fotos[30];
           // for (int i = 0; i < 30; i++)
           // {
           //     f[i] = new Fotos() { FotoID=i+2 };
                
           // }
           // all.Contacts.Save();
           // Orders[] o = new Orders[8];
           // for (int i = 0; i < 8; i++)
           // {
           //     o[i] = new Orders() {OrderID=i+2, Description = i.ToString(), Date = DateTime.Now };
           //     //all.Contacts.Save();
           //     //all.Orders.AddOrUpdate(o[i]);
           //     //all.Contacts.AddOrUpdate(new Contacts() { OrderID = o[i].OrderID, Mail = i.ToString() + "@FotoApp.pl", TelephoneNumber = "12" + i.ToString() + i.ToString() + i.ToString() });
           // }
           // all.Contacts.Save();
           // Random rnd = new Random();
           // for (int i = 0; i < 20; i++)
           // {
           //     for (int j = 0; j < 30; j++)
           //     {
           //         for (int z = 0; z < 8; z++)
           //         {
           //             all.OrderFotos.AddOrUpdate(new OrderFotos()
           //             {
           //                 FotoID = f[j].FotoID,
           //                 OrderID = o[z].OrderID,
           //                 Height = p[i].Height,
           //                 Length = p[i].Length,
           //                 TypeID = p[i].TypeID,
           //                 Quantity = rnd.Next(1, 11)
           //             });
           //         }
           //         all.Contacts.Save();
           //     }
           // }
           // all.Settings.AddOrUpdate(new Settings() { Area = "lang", Target = "en", Value = "pl_PL" });
           // all.Settings.AddOrUpdate(new Settings() { Area = "acc", Target = "size", Value = "100" });
           // all.Contacts.Save();

            Console.WriteLine("koniec");
            Console.ReadKey();
        }

    }

}
