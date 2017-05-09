using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FotoApp.ViewModels
{
    public class AndOrderViewModel : ViewModelBase.ViewModelBase
    {
        public delegate void EndOrderDelegate();

        public event EndOrderDelegate andOrder;

        public AndOrderViewModel(GetFotoViewModel _getFoto) : base(_getFoto)
        {
            
        }

        private void AndOrder()
        {
            Thread.Sleep(3000);
            andOrder?.Invoke();
        }
    }
}
