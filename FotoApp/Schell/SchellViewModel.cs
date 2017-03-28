using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.ViewModels;

namespace FotoApp.Schell
{
    public class SchellViewModel: Conductor<object>
    {
        public SchellViewModel()
        {
            ActivateItem(new StartViewModel(this));
            base.DisplayName = "FotoApp";
            
        }

        public sealed override void ActivateItem(object item)
        {
            base.ActivateItem(item);
        }
    }
}
