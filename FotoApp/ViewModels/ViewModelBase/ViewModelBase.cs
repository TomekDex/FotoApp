using Caliburn.Micro;
using FotoApp.Interface;

namespace FotoApp.ViewModels.ViewModelBase
{
    public abstract class ViewModelBase : ValidateModelBase, IViewModelEventAggregator, IViewModel
    {
        private bool _isValid;
        public IEventAggregator EventAggregator { get; set; }
       protected readonly GetFotoViewModel _getFoto;


        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                NotifyOfPropertyChange(()=>IsValid);
            }
        }


       public ViewModelBase(GetFotoViewModel _getFoto, IEventAggregator eventAggregator )
       {
           this._getFoto = _getFoto;
           EventAggregator = eventAggregator;
       }
    }
}
