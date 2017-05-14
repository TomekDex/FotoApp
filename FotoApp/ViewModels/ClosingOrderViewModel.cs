using System.ComponentModel.DataAnnotations;
using Caliburn.Micro;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Validation;

namespace FotoApp.ViewModels
{
    public class ClosingOrderViewModel : ViewModelBase.ViewModelBase
    {

        #region Propertis

        private string _discriptionOrder;
       

        [Required(ErrorMessage = "Nie podano imienia")]
        [ExekuteCharacter("!#$%^&*()", ErrorMessage = "Nieprawidłowe znaki")]
        public string DiscriptionOrder
        {
            get => _discriptionOrder;
            set
            {
                _discriptionOrder = value;
                NotifyOfPropertyChange(() => DiscriptionOrder);
                EventAggregator.PublishOnCurrentThread(StringEmpty());
            }
        }

        #endregion

        #region Constractor

        public ClosingOrderViewModel(GetFotoViewModel getFoto) :base(getFoto)
        {
            EventAggregator.PublishOnCurrentThread(StringEmpty());
            getFoto.raport += FinalOrder;
        }

        #endregion

        #region Actions

        private void FinalOrder()
        {
            var order = NewOrder.New_Order;
            order.AddDiscripionOrder(DiscriptionOrder);
            var raport = new CreateFinalRaport();
            raport.CreateRaport();
            order.CreateNewOrders();
        }

        private bool StringEmpty()
        {
            var o = !string.IsNullOrWhiteSpace(DiscriptionOrder);
            return o;
        }
        #endregion
    }
}
