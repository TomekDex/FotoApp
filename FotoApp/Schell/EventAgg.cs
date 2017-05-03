using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Pref;
using FotoApp.Pref.Helpers;

namespace FotoApp.Schell
{
    public class EventAgg : IViewModelEventAggregator
    {
        public  IEventAggregator EventAggregator { get; set; }

        private static readonly object O = new object();
        private static EventAgg _preference;
        private EventAgg()
        {
            EventAggregator = new EventAggregator();
        }

        public static EventAgg Agregator
        {
            get
            {
                lock (O)
                {
                    if (null == _preference)
                    {
                        _preference = new EventAgg();
                    }
                }
                return _preference;
            }
        }
    }
}

