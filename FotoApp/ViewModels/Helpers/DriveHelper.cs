using System.Collections.Generic;
using System.IO;
using FotoApp.Const;
using FotoApp.Models.Drive;

namespace FotoApp.ViewModels.Helpers
{
    public class DriveHelper
    {
        private Drive _d1;
        private Drive _d2;
        private Drive _d3;
        private Drive _d4;

        public DriveHelper(Drive d1, Drive d2, Drive d3, Drive d4)
        {
            _d1 = d1;
            _d1.IsEnable = false;
            _d1.Content = DriveStrings.Card1;
            _d2 = d2;
            _d2.IsEnable = false;
            _d2.Content = DriveStrings.Card2;
            _d3 = d3;
            _d2.IsEnable = false;
            _d3.Content = DriveStrings.Card3;
            _d4 = d4;
            _d4.IsEnable = false;
            _d4.Content = DriveStrings.Card4;
        }

        public DriveHelper(Drive d1, Drive d2, Drive d3)
        {
            _d1 = d1;
            _d1.IsEnable = false;
            _d1.Content = DriveStrings.Us1;
            _d2 = d2;
            _d2.IsEnable = false;
            _d2.Content = DriveStrings.Us2;
            _d3 = d3;
            _d3.IsEnable = false;
            _d3.Content = DriveStrings.Us3;
        }

        public DriveHelper(Drive d1)
        {
            _d1 = d1;
            _d1.IsEnable = false;
            _d1.Content = DriveStrings.Cd;
        }

        public void ActivUsbDrive(List<DriveInfo> drive)
        {
            if (drive.Count == 1)
            {
                _d1.DriveInfo = drive[0];
                _d1.IsEnable = true;
            }
            if (drive.Count == 2)
            {
                _d2.DriveInfo = drive[1];
                _d1.IsEnable = true;
            }
            if (drive.Count == 3)
            {
                _d3.DriveInfo = drive[2];
                _d3.IsEnable = true;
            }
        }

        public void ActivCardDrive(List<DriveInfo> drive)
        {
            if (drive.Count == 1)
            {
                _d1.DriveInfo = drive[0];
                _d1.IsEnable = true;
            }
            if (drive.Count == 2)
            {
                _d2.DriveInfo = drive[1];
                _d1.IsEnable = true;
            }
            if (drive.Count == 3)
            {
                _d3.DriveInfo = drive[2];
                _d3.IsEnable = true;
            }
            if (drive.Count == 4)
            {
                _d4.DriveInfo = drive[3];
                _d4.IsEnable = true;
            }
        }
        public void ActivCdDrive(List<DriveInfo> drive)
        {
            if (drive.Count == 1)
            {
                _d1.DriveInfo = drive[0];
                _d1.IsEnable = true;
            }
        }
    }
}
