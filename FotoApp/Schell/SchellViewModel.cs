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
        private bool _onClose;
        public SchellViewModel()
        {
            _onClose = false;
            ActivateItem(new StartViewModel(this));
            base.DisplayName = "FotoApp";
#if DEBUG
           ActivateItem(new GetFotoViewModel(this));
#endif

        }

        public void OnClose()
        {
        }

        public sealed override void ActivateItem(object item)
        {
            base.ActivateItem(item);
        }

        public void OnClosing()
        {
            var start = new StartViewModel(this);
            _onClose = true;
            start.onClosing += OnClose;
            ActivateItem(start);
        }

    }
}
