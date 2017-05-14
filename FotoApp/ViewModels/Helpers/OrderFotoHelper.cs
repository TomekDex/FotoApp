using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Annotations;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoAppDB;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels.Helpers
{
    public class OrderFotoHelper
    {
        [NotNull] private readonly Fotos _foto;
        [NotNull] private readonly Papers _paper;
        private readonly int _quantity;
        private OrderFotos _orderFoto;

        /// <summary>
        /// Pomocnik dodający do bazy zdiecie do wydruku ilość wymiary i rodzaj papieu
        /// </summary>
        /// <param name="foto">zdiecie </param>
        /// <param name="paper"> papier rodzaj i wymiary</param>
        /// <param name="quantity">ilośc</param>
        public OrderFotoHelper(Fotos foto, Papers paper, int quantity)
        {
            _foto = foto;
            _paper = paper;
            _quantity = quantity;
        }

        
        /// <summary>
        /// Dodaje do bazy obiekt
        /// </summary>
        public void AddOrderFoto()
        {
            var all = FotoAppRAll.Ins;
            CreateOrder(all);
            all.OrderFotos.Add(_orderFoto);
            all.OrderFotos.Save();
        }

        /// <summary>
        /// tworzy nowe orderfotos
        /// </summary>
        /// <param name="all"></param>
        private void CreateOrder(FotoAppRAll all)
        {
            var o = NewOrder.New_Order;
            var order = o.GetNewOrders();
            _orderFoto = new OrderFotos();
            _orderFoto.FotoID = all.Fotos.Get(_foto).FotoID;
            _orderFoto.Quantity = _quantity;
            _orderFoto.TypeID = _paper.TypeID;
            _orderFoto.Height = _paper.Height;
            _orderFoto.Width = _paper.Width;
        }

        /// <summary>
        /// Zmienia parametry zdięcia w bazie 
        /// </summary>
        /// <param name="paper"></param>
        /// <param name="quantity"></param>
        public void ChangeOrderFoto(Papers paper, int quantity)
        {
            var all = FotoAppRAll.Ins;
            CreateOrder(all);
            var order = all.OrderFotos.Get(_orderFoto);
            if (null != paper)
            {
                order.Height = paper.Height;
                order.Width = paper.Width;
            }
            if (quantity <= 1)
                order.Quantity = quantity;
            all.OrderFotos.AddOrUpdate(order);
            all.OrderFotos.Save();
        }

        /// <summary>
        /// Usuwa wpis z tabeli orderfotos oraz sprawdza czy są jeszcze wpisy z takim samym zdięciem jesli nie usuwa również to zdiecie z tabeli fotos
        /// </summary>
        public void DelOrderfoto()
        {
            var all = FotoAppRAll.Ins;
            CreateOrder(all);
            var orderDel = all.OrderFotos.Get(_orderFoto);
            var fId = _orderFoto.FotoID;
            var foto = new Fotos
            {
                FotoID = fId,
                OrderID = NewOrder.New_Order.GetNewOrders().OrderID
            };
            var fotoDel = all.Fotos.Get(foto);
            all.OrderFotos.Delete(orderDel);
            all.OrderFotos.Save();
        }
        /// <summary>
        /// Usuwa Foto z bazy danych
        /// </summary>
        public void DelFoto()
        {
            var all = FotoAppRAll.Ins;
            var fId = _orderFoto.FotoID;
            var foto = new Fotos
            {
                FotoID = fId,
                OrderID = NewOrder.New_Order.GetNewOrders().OrderID
            };
            var fotoDel = all.Fotos.Get(foto);
            var countOrderByFoto = all.OrderFotos.GetFotoInOrder(fotoDel).Count;
            if (countOrderByFoto == 0)
            {
                all.Fotos.Delete(fotoDel);
                all.Fotos.Save();
            }
        }
    }
}

