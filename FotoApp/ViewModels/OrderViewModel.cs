using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Helpers;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels
{
    public sealed class OrderViewModel: ViewModelBase.ViewModelBase, IHandle<OrderFoto>
    {
        public delegate void ChangeOrder();
        public event ChangeOrder changeOrder;

        #region Proportis

        private BindableCollection<OrderFoto> _orderFotoColection;

        public BindableCollection<OrderFoto> OrderFotoColection
        {
            get => _orderFotoColection;
            set
            {
                _orderFotoColection = value;
                NotifyOfPropertyChange(() => OrderFotoColection);
            }
        }

        #endregion

        #region Constractor

        public OrderViewModel(GetFotoViewModel getFoto) : base(getFoto)
        {
            EventAggregator.Subscribe(this);
            _orderFotoColection = new BindableCollection<OrderFoto>();
        }

        #endregion

        #region Actios

        public void Del(object o)
        {
            var tmp = o as OrderFoto;
            var of = new OrderFotoHelper(tmp.Foto, tmp.Paper, tmp.Quantity);
            of.DelOrderfoto();
            OrderFotoColection.Remove(tmp);
            NotifyOfPropertyChange(() => OrderFotoColection);
            OnChangeOrder();
        }

        public void Handle(OrderFoto message)
        {
            _orderFotoColection.Add(message);
        }

        private void OnChangeOrder()
        {
            changeOrder?.Invoke();
        }
        #endregion


    }
}
