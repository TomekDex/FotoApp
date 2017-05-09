using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Models.Raport;
using FotoApp.ViewModels.Helpers;

namespace FotoApp.ViewModels
{
    public class RaportViewModel : ViewModelBase.ViewModelBase
    {
        private BindableCollection<Raport> _raport;
        private int _totalPrice;

        public BindableCollection<Raport> Raport
        {
            get => _raport;
            set
            {
                _raport = value;
                NotifyOfPropertyChange(()=> Raport);
            }
        }

        public int TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                NotifyOfPropertyChange(() => TotalPrice);
            }
        }

        #region Constractor

        public RaportViewModel(GetFotoViewModel _getFoto) : base(_getFoto)
        {
            _getFoto.raport += RaportOrder;
        }

        void RaportOrder()
        {
            var r= new RaportHelper();
            r.CreateRaport();
            _raport = r.Raport;
            _totalPrice = r.TotalPrice;
            NotifyOfPropertyChange(()=> Raport);
        }

        #endregion
    }
}
