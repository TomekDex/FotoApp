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

        private void CreateOrder(FotoAppRAll all)
        {
            var o = NewOrder.New_Order;
            var order = o.GetNewOrders();
            _orderFoto = new OrderFotos();
            //_orderFoto.Fotos.OrderID = order.OrderID;
            _orderFoto.FotoID = all.Fotos.Get(_foto).FotoID;
            _orderFoto.Quantity = _quantity;
            _orderFoto.TypeID = _paper.TypeID;
            _orderFoto.Height = _paper.Height;
            _orderFoto.Width = _paper.Width;
        }

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
            if (quantity != 1)
                order.Quantity = quantity;
            all.OrderFotos.AddOrUpdate(order);
            all.OrderFotos.Save();
        }

        public void DelOrderfoto()
        {
            var all = FotoAppRAll.Ins;
            CreateOrder(all);
            var del = all.OrderFotos.Get(_orderFoto);
            all.OrderFotos.Delete(del);
            all.OrderFotos.Save();
        }
    }
}
