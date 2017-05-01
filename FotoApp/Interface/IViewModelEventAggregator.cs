using System.Drawing.Text;
using Caliburn.Micro;
using FotoApp.Schell;

namespace FotoApp.Interface
{
    public interface IViewModelEventAggregator
    {
        IEventAggregator EventAggregator { get; set; }
    }
}
