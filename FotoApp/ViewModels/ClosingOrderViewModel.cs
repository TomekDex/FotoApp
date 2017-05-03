using System.ComponentModel.DataAnnotations;
using Caliburn.Micro;
using FotoApp.ViewModels.EvenArgs;
using FotoApp.ViewModels.EvenArgs.Hendler;
using FotoApp.ViewModels.Validation;

namespace FotoApp.ViewModels
{
    public class ClosingOrderViewModel : ViewModelBase.ViewModelBase
    {

        #region Propertis

        private string _name;
        private string _phone;
        private string _mail;

        [Required(ErrorMessage = "Nie podano imienia")]
        [ExekuteCharacter("!#$%^&*()", ErrorMessage = "Nieprawidłowe znaki")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                EventAggregator.PublishOnCurrentThread( StringEmpty());

            }
        }
        [Required(ErrorMessage = "Nie podano telefonu")]
        [ExekuteCharacter("!#$%^&*()", ErrorMessage = "Wprowadzono nieprawidłowe znaki")]
        [Phone ( ErrorMessage =  "To nie jest umer telefonu")]
        public string Phone
        {
            get { return _phone; }

            set
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
                EventAggregator.PublishOnCurrentThread(StringEmpty());

            }
        }

        [Required(ErrorMessage = "Nie podano Maila")]
        [EmailAddress(ErrorMessage = "Adres eMaili jest nie prawdłowy")]
        public string Mail
        {
            get { return _mail; }

            set
            {
                _mail = value;
                NotifyOfPropertyChange(() => Mail);
                EventAggregator.PublishOnCurrentThread(StringEmpty());
            }
        }

        #endregion

        #region Constractor

        public ClosingOrderViewModel(GetFotoViewModel getFoto) :base(getFoto)
        {
            EventAggregator.PublishOnCurrentThread(StringEmpty());
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

        private bool StringEmpty()
        {
            var o = !string.IsNullOrWhiteSpace(Name) 
                && !(string.IsNullOrWhiteSpace(Phone) 
                || string.IsNullOrWhiteSpace(Mail));
            return o;
        }
        #endregion
    }
}
