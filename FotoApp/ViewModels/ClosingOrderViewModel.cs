using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Schell;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ClosingOrderViewModel : Screen, IViewModel
    {
        public IViewModel MainPanel { get; set; }
        private readonly GetFotoViewModel _getFoto;
        #region Propertis

        private string _name;
        private string _phone;
        private string _mail;

        public string Name
        {
            get { return  _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(()=> Name);
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }

        #endregion

        #region Constractor

        public ClosingOrderViewModel(GetFotoViewModel getFoto)
        {
            _getFoto = getFoto;
            getFoto.FinalColectionDelegat += FinalOrder;
        }
        #endregion

        #region Actions

        public void FinalOrder()
        { 
            var tmp = new FinalOrder();
            var hendler = new FinalOrderHendler();
            tmp.finalOrderDelegate += hendler.FinalOrder;
            tmp.GetFotoColection(_getFoto, Name, Phone, Mail);
        }
        


        #endregion

    }
}
