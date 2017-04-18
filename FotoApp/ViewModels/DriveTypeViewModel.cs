using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.ViewModels.Actions;

namespace FotoApp.ViewModels
{
    public class DriveTypeViewModel : ViewModelBase.ViewModelBase
    {
        public BindableCollection<DriveInfo> Drive { get; set; }
        public DriveTypeViewModel(GetFotoViewModel _getFoto, IEventAggregator eventAggregator) 
            : base(_getFoto, eventAggregator)
        {
            Drive = GetDriveType.GetDrive();
            var t = new Thread(RefreshDriveType);
        }

        public void DriveT(object o)
        {
            var tmp = o as DriveInfo;
            EventAggregator.PublishOnCurrentThread(tmp);
        }

        private void RefreshDriveType()
        {
            while (true)
            {
                Drive = GetDriveType.GetDrive();
                NotifyOfPropertyChange(() => Drive);
            }
        }

    }
}
