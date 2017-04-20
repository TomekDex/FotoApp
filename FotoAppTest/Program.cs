using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;
using FotoAppDB.DBModel;
using FotoAppDBTest;

namespace FotoAppTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DriveInfo[] d = DriveInfo.GetDrives();

            DirectoryInfo dir = d[1].RootDirectory;



            LoadFoto l = new LoadFoto( "*.jpg");
            l.GetDirectoryType(dir.Name);
            var c = l.ListFile;

            BindableCollection<Foto> foto = new BindableCollection<Foto>();

            object i = new object();
            int index = 1;
            string newDir = @"E:\Users";
            System.IO.Directory.CreateDirectory(newDir);

            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            // Be sure to add a reference to System.Drawing.dll.
            Parallel.ForEach(c, (currentFile) =>
            {
                string filename = System.IO.Path.GetFileName(currentFile);
                Foto w = new Foto();
                lock (i)
                {
                    w.Index = index;
                    index++;
                }
                w.bitmap = new BitmapImage(new Uri(currentFile, UriKind.Absolute));
                foto.Add(w);
                

                // Peek behind the scenes to see how work is parallelized.
                // But be aware: Thread contention for the Console slows down parallel loops!!!

                Console.WriteLine("Processing {0} on thread {1}", filename, w.Index);
                //close lambda expression and method invocation
            });


            // Keep the console window open in debug mode.
            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();



            Console.ReadKey();
            
        }

        private static void Addsetings()
        {
            
           
            //Settings s = new Settings() { Area = "lang", Target = "pl_en", Value = "pl_PL" };
            //var s = all.Settings.Get()
            //all.Settings.Update(s);
        }
    }
}
