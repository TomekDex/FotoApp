using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Schell;

namespace FotoApp.ViewModels
{
    public class StartViewModel : PropertyChangedBase
    {
        public SchellViewModel Schell { get; set; }


        public StartViewModel(SchellViewModel schell)
        {
            Schell = schell;
        }

        public void Btn()
        {
            
        }
    }
}
