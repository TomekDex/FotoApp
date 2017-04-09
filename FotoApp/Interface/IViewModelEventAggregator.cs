using Caliburn.Micro;

namespace FotoApp.Interface
{
    public interface IViewModelEventAggregator
    {
        IEventAggregator EventAggregator { get; set; }

    }
}
