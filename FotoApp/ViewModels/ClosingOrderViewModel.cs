using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Schell;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ClosingOrderViewModel : ViewModelBase.ViewModelBase
    {

        #region Propertis

        private string _name;
        private string _phone;
        private string _mail;

        [Required(ErrorMessage = "Nie podano imienia")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                EventAggregator.PublishOnCurrentThread( stringEmpty());

            }
        }
        [Required(ErrorMessage = "Nie podano telefonu")]
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
                EventAggregator.PublishOnCurrentThread(stringEmpty());

            }
        }

        [Required(ErrorMessage = "Nie podano Maila")]
        public string Mail
        {
            get => _mail;
            set
            {
                _mail = value;
                NotifyOfPropertyChange(() => Mail);
                EventAggregator.PublishOnCurrentThread(stringEmpty());
            }
        }

        #endregion

        #region Constractor

        public ClosingOrderViewModel(GetFotoViewModel getFoto, IEventAggregator eventAggregator) :base(getFoto, eventAggregator)
        {
            getFoto.FinalColectionDelegat += FinalOrder;
            EventAggregator.PublishOnCurrentThread(stringEmpty());
        }

        #endregion

        #region Actions

        public void FinalOrder()
        {
            var tmp = new FinalOrder();
            var hendler = new FinalOrderHendler();
            tmp.finalOrderDelegate += hendler.FinalOrder;
            tmp.GetFotoColection(base._getFoto, Name, Phone, Mail);
        }

        private bool stringEmpty()
        {
            return string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Mail) && IsValid;
        }
        #endregion
    }
}
