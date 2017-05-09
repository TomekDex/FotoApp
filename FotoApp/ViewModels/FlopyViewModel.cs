using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using FotoApp.Models.Drive;
using FotoApp.Schell.Actions;
using FotoApp.ViewModels.Helpers;

namespace FotoApp.ViewModels
{
    public class FlopyViewModel :ViewModelBase.ViewModelBase
    {
        private BindableCollection<Drive> _drive;
        public Drive Usb1Drive { get; set; }
        public Drive Usb2Drive { get; set; }
        public Drive Usb3Drive { get; set; }
        public Drive  Card1Drive { get; set; }
        public Drive  Card2Drive { get; set; }
        public Drive  Card3Drive { get; set; }
        public Drive  Card4Drive { get; set; }
        public Drive  CdDrive { get; set; }

        private readonly ActDeActDrive _c;

        public BindableCollection<Drive> Drive {
            get => _drive;
            set
            {
                _drive = value;
                NotifyOfPropertyChange(()=> Drive);
            } }

        public FlopyViewModel(GetFotoViewModel _getFoto) : base(_getFoto)
        {
            _c = new ActDeActDrive();
            _c.ActivAll();
            Active();
            var us = new DriveHelper(Usb1Drive,Usb2Drive,Usb3Drive);
            var cd = new DriveHelper(CdDrive);
            var ca = new DriveHelper(Card1Drive,Card2Drive,Card3Drive,Card4Drive);
            us.ActivCardDrive(_c.UsbDriveInfos);
            cd.ActivCdDrive(_c.CdDriveInfos);
            ca.ActivCardDrive(_c.CardDriveInfos);
            _c.insertCD += ActivCd;
            _c.insertCard += ActivCard;
            _c.insertUSB += ActivUsb;
        }

        public void Flopy(object o)
        {
            var drive = o as Drive;
            if (drive.DriveInfo == null)
            {
                MessageBox.Show("dysk jest nie aktywny");
                return;
            }
            _getFoto.ActivMainPanel(drive.DriveInfo);
        }

        public void ActivCd()
        {
            var cd = new DriveHelper(CdDrive);
            cd.ActivCdDrive(_c.CdDriveInfos);
        }

        public void ActivUsb()
        {
            var us = new DriveHelper(Usb1Drive, Usb2Drive, Usb3Drive);
            us.ActivCardDrive(_c.UsbDriveInfos);
        }

        public void ActivCard()
        {
            var ca = new DriveHelper(Card1Drive, Card2Drive, Card3Drive, Card4Drive);
            ca.ActivCardDrive(_c.CardDriveInfos);
        }

        private void Active()
        {
            _drive = new BindableCollection<Drive>();
            _drive.Add(Usb1Drive = new Drive());
            _drive.Add(Usb2Drive = new Drive());
            _drive.Add(Usb3Drive = new Drive());
            _drive.Add(Card1Drive = new Drive());
            _drive.Add(Card2Drive = new Drive());
            _drive.Add(Card3Drive = new Drive());
            _drive.Add(Card4Drive = new Drive());
            _drive.Add(CdDrive = new Drive());
        }
    }
}
