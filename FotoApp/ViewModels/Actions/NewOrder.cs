using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoAppDB;
using FotoAppDB.DBModel;
using Path = System.Windows.Shapes.Path;

namespace FotoApp.ViewModels.Actions
{
    public class NewOrder
    {
        private string _directoryName;
        private Orders _newOrders;

        public string DirectoryName { get; private set; }
        public Orders NewOrders { get; private set; }

        public NewOrder()
        {
            CreateNewOrders();
        }

        public Orders GetNewOrders()
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            var n = all.Orders.Get(_newOrders);
            return n;
        }

        public void CreateNewOrders()
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            _newOrders = new Orders ();

            all.Orders.Add(_newOrders);
            all.Save();
#if DEBUG
            Console.WriteLine(GetNewOrders().OrderID.ToString());
            Console.WriteLine("stworzyłem");
#endif

        }
        public void DeleteNewOrders()
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            all.Orders.Delete(_newOrders);
#if DEBUG
            Console.WriteLine("stworzyłem");
#endif
        }


        public string CreateDirectory(string defaultPath)
        {

            string orederPathDirectory = System.IO.Path.Combine(defaultPath, _directoryName);
            if (!Directory.Exists(orederPathDirectory))
            {
                Directory.CreateDirectory(orederPathDirectory);
            }
            return orederPathDirectory;
        }
    }
}
