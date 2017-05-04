namespace FotoAppDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DBModel;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<FotoAppDB.FotoAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FotoAppDB.FotoAppDbContext context)
        {
            #region price list
            context.Language.AddOrUpdate(a => a.Language, new Languages() { Language = "pl_PL", Base = null });
            var shiny = context.TypeText.Where(a => a.Text == "B³yszcz¹cy").SingleOrDefault();
            if (shiny == null) shiny = new TypeTexts() { Types = new Types(), Text = "B³yszcz¹cy", Language = "pl_PL" };
            var mat = context.TypeText.Where(a => a.Text == "Matowy").SingleOrDefault();
            if (mat == null) mat = new TypeTexts() { Types = new Types(), Text = "Matowy", Language = "pl_PL" };
            context.TypeText.AddOrUpdate(shiny);
            context.TypeText.AddOrUpdate(mat);
            context.SaveChanges();
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 900, Height = 1300, Text = "9x13", Language = "pl_PL", Sizes = new Sizes() { Width = 900, Height = 1300 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 1000, Height = 1500, Text = "10x15", Language = "pl_PL", Sizes = new Sizes() { Width = 1000, Height = 1500 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 1300, Height = 1800, Text = "13x18", Language = "pl_PL", Sizes = new Sizes() { Width = 1300, Height = 1800 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 1500, Height = 2100, Text = "15x21", Language = "pl_PL", Sizes = new Sizes() { Width = 1500, Height = 2100 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 1800, Height = 2400, Text = "18x24", Language = "pl_PL", Sizes = new Sizes() { Width = 1800, Height = 2400 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 2000, Height = 2500, Text = "20x25", Language = "pl_PL", Sizes = new Sizes() { Width = 2000, Height = 2500 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 2100, Height = 3000, Text = "21x30", Language = "pl_PL", Sizes = new Sizes() { Width = 2100, Height = 3000 } });
            context.SizeText.AddOrUpdate(new SizeTexts() { Width = 2400, Height = 3000, Text = "24x30", Language = "pl_PL", Sizes = new Sizes() { Width = 2400, Height = 3000 } });
            context.SaveChanges();
            foreach (Types type in context.Type) foreach (Sizes s in context.Size)
                {
                    context.Paper.AddOrUpdate(new Papers() { Availability = null, Height = s.Height, TypeID = type.TypeID, Width = s.Width });
                }
            context.SaveChanges();
            var t = mat;

            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 1, Price = 100 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 11, Price = 70 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 51, Price = 65 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 101, Price = 60 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 201, Price = 55 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 301, Price = 53 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 401, Price = 51 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 501, Price = 49 });

            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 1, Price = 100 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 11, Price = 80 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 51, Price = 75 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 101, Price = 70 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 201, Price = 66 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 301, Price = 63 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 401, Price = 61 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 501, Price = 59 });

            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 1, Price = 160 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 51, Price = 150 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 101, Price = 140 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 201, Price = 130 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 301, Price = 120 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 401, Price = 110 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 501, Price = 100 });

            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 1, Price = 200 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 51, Price = 180 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 101, Price = 160 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 201, Price = 150 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 301, Price = 140 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 401, Price = 130 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 501, Price = 120 });

            context.Price.AddOrUpdate(new Prices() { Width = 1800, Height = 2400, TypeID = t.TypeID, Quantity = 1, Price = 500 });
            context.Price.AddOrUpdate(new Prices() { Width = 2000, Height = 2500, TypeID = t.TypeID, Quantity = 1, Price = 600 });
            context.Price.AddOrUpdate(new Prices() { Width = 2100, Height = 3000, TypeID = t.TypeID, Quantity = 1, Price = 800 });
            context.Price.AddOrUpdate(new Prices() { Width = 2400, Height = 3000, TypeID = t.TypeID, Quantity = 1, Price = 1000 });

            t = shiny;
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 1, Price = 100 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 11, Price = 70 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 51, Price = 65 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 101, Price = 60 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 201, Price = 55 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 301, Price = 53 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 401, Price = 51 });
            context.Price.AddOrUpdate(new Prices() { Width = 900, Height = 1300, TypeID = t.TypeID, Quantity = 501, Price = 49 });

            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 1, Price = 100 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 11, Price = 80 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 51, Price = 75 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 101, Price = 70 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 201, Price = 66 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 301, Price = 63 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 401, Price = 61 });
            context.Price.AddOrUpdate(new Prices() { Width = 1000, Height = 1500, TypeID = t.TypeID, Quantity = 501, Price = 59 });

            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 1, Price = 160 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 51, Price = 150 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 101, Price = 140 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 201, Price = 130 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 301, Price = 120 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 401, Price = 110 });
            context.Price.AddOrUpdate(new Prices() { Width = 1300, Height = 1800, TypeID = t.TypeID, Quantity = 501, Price = 100 });

            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 1, Price = 200 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 51, Price = 180 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 101, Price = 160 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 201, Price = 150 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 301, Price = 140 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 401, Price = 130 });
            context.Price.AddOrUpdate(new Prices() { Width = 1500, Height = 2100, TypeID = t.TypeID, Quantity = 501, Price = 120 });

            context.Price.AddOrUpdate(new Prices() { Width = 1800, Height = 2400, TypeID = t.TypeID, Quantity = 1, Price = 500 });
            context.Price.AddOrUpdate(new Prices() { Width = 2000, Height = 2500, TypeID = t.TypeID, Quantity = 1, Price = 600 });
            context.Price.AddOrUpdate(new Prices() { Width = 2100, Height = 3000, TypeID = t.TypeID, Quantity = 1, Price = 800 });
            context.Price.AddOrUpdate(new Prices() { Width = 2400, Height = 3000, TypeID = t.TypeID, Quantity = 1, Price = 1000 });
            #endregion
            Orders[] order = new Orders[10];
            context.Order.RemoveRange(context.Order);
            for (int i = 0; i < 10; i++)
            {
                order[i] = new Orders() { Date = DateTime.Now };
                context.Order.AddOrUpdate(order[i]);
            }
            context.SaveChanges();
            Fotos[][] foto = new Fotos[10][];
            for (int i = 0; i < 10; i++) foto[i] = new Fotos[10];
            //var paper = context.Paper.ToList();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    foto[i][j] = new Fotos() { OrderID = order[i].OrderID, Name = order[i].ToString() + " " + j.ToString() };
                    context.Foto.AddOrUpdate(foto[i][j]);
                    context.SaveChanges();
                    foreach (Papers p in context.Paper)
                        if (0 == rand.Next(0, 2))
                        {
                            context.OrderFoto.AddOrUpdate(new OrderFotos() { FotoID = foto[i][j].FotoID, Height = p.Height, Width = p.Width, TypeID = p.TypeID, Quantity = rand.Next(1, 100) });
                        }
                }
            }
            context.OrderFoto.AddOrUpdate(new OrderFotos() { Fotos = new Fotos() { Orders = new Orders() { Date = DateTime.Now }, Name = "test1" }, Height = 1800, Width = 1300, Quantity = 1, TypeID = mat.TypeID });
            context.OrderFoto.AddOrUpdate(new OrderFotos() { Fotos = new Fotos() { Orders = new Orders() { Date = DateTime.Now }, Name = "test1" }, Height = 1800, Width = 1300, Quantity = 100000, TypeID = mat.TypeID });

            TypeTexts[] tt = new TypeTexts[5];
            for (int i = 0; i < 5; i++)
            {
                tt[i] = context.TypeText.Where(a => a.Text == "test" + i.ToString()).SingleOrDefault();
                if (tt[i] == null) tt[i] = new TypeTexts() { Types = new Types(), Text = "test" + i.ToString(), Language = "pl_PL" };

            }
            context.SaveChanges();
            List<Papers> paper = new List<Papers>();
            foreach (Sizes s in context.Size)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (rand.Next(0, 1) == 0)
                    {
                        var p = new Papers() { Availability = rand.Next(50, 2000), Sizes = s, Types = tt[i].Types };
                        context.Paper.AddOrUpdate(p);
                        paper.Add(p);
                        

                    }
                }
            }
            context.SaveChanges();
            foreach (Papers p in paper)
                for (int j = 0; j < rand.Next(4, 8); j++)
                {
                    context.Price.AddOrUpdate(new Prices() { Height = p.Height, TypeID = p.TypeID, Width = p.Width, Price = 100 - j * 5, Quantity = j * 100 });
                }
            context.SaveChanges();

            Orders[] ordert = new Orders[10];
            for (int i = 0; i < 10; i++)
            {
                ordert[i] = new Orders() { Date = DateTime.Now };
                context.Order.AddOrUpdate(ordert[i]);
            }
            context.SaveChanges();


            Fotos[][] fotot = new Fotos[10][];
            for (int i = 0; i < 10; i++) fotot[i] = new Fotos[5];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    fotot[i][j] = new Fotos() { OrderID = ordert[i].OrderID, Name = ordert[i].ToString() + " " + j.ToString() };
                    context.Foto.AddOrUpdate(fotot[i][j]);
                    context.SaveChanges();
                    foreach (Papers p in context.Paper)
                        if (0 == rand.Next(0, 1))
                        {
                            context.OrderFoto.AddOrUpdate(new OrderFotos() { FotoID = fotot[i][j].FotoID, Height = p.Height, Width = p.Width, TypeID = p.TypeID, Quantity = rand.Next(1, 100) });
                        }
                }
            }
            context.SaveChanges();
        }
    }
}
