using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;

namespace FotoApp.ViewModels
{
    public class OrderViewModel: ViewModelBase.ViewModelBase, IHandle<OrderFoto>
    {
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

        public OrderViewModel(GetFotoViewModel _getFoto) : base(_getFoto)
        {
            EventAggregator.Subscribe(this);
            _orderFotoColection = new BindableCollection<OrderFoto>();
        }

        public void DelOrderFoto(object o)
        {
            
        }

        public void Handle(OrderFoto message)
        {
            _orderFotoColection.Add(message);
        }
    }
}
