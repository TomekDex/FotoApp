using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoAppDB;
using FotoAppDB.DBModel;


namespace FotoApp.ViewModels.Actions
{
    /// <summary>
    /// Klasa tworząca nowe zlecenie jest singletone 
    /// </summary>
    public class NewOrder
    {
        private string _directoryName;
        private string _finalPath;
        private Orders _orders;
        private static object _o = new object();
        private static NewOrder _orderNew;
        public string DirectoryName => _directoryName;
        public string FinalPath => _finalPath;
        public Orders Orders => _orders;

        public static  NewOrder New_Order
        {
            get
            {
                lock (_o)
                {
                    if (null == _orderNew)
                    {
                       _orderNew = new NewOrder(); 
                    }
                    return _orderNew;
                }   
            }
            
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        private NewOrder()
        {
            CreateNewOrders();
        }
        /// <summary>
        /// Pobiera nowe zlecenie z bazie danych
        /// </summary>
        /// <returns></returns>
        public Orders GetNewOrders()
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            var n = all.Orders.Get(_orders);
            return n;
        }
        /// <summary>
        /// Tworzy nowe zlecenie w bazie danych
        /// </summary>
        public void CreateNewOrders()
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            _orders = new Orders ();
            _orders.Date = DateTime.Today;
            all.Orders.Add(_orders);
            all.Save();
        }
        /// <summary>
        /// Usuwa zlecenie  z bazy oraz katalog wraz zplikami zawartymi w nim
        /// </summary>
        public void DeleteNewOrders()
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            /*var delFoto = all.OrderFotos.AllFotosInOrder(_orders);
            foreach (var e in delFoto)
            {
                var foto = all.Fotos.Get(e);
            }*/
            all.Orders.Delete(_orders);
            Directory.Delete(_finalPath, true);
        }

        /// <summary>
        /// Torzy katalog w podanej scierzce
        /// </summary>
        /// <param name="defaultPath"></param>
        public void CreateDirectory(string defaultPath)
        {
            _directoryName = string.Format("{0}/{1}", GetNewOrders().Date.ToString("Y"), GetNewOrders().OrderID);
            string orederPathDirectory = Path.Combine(defaultPath, _directoryName);
            if (!Directory.Exists(orederPathDirectory))
            {
                Directory.CreateDirectory(orederPathDirectory);
            }
            _finalPath = Path.GetFullPath(orederPathDirectory);
        }
    }
}
