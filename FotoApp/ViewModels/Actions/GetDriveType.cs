﻿using System.IO;
using Caliburn.Micro;

namespace FotoApp.ViewModels.Actions
{
    public  class GetDriveType
    {
        public GetDriveType() 
        {

        }
       
        public static BindableCollection<DriveInfo> GetDrive()
        {
            var d = new BindableCollection<DriveInfo>();
            var loadedDrives = DriveInfo.GetDrives();
            foreach (var loadedDrive in loadedDrives)
            {
                if (loadedDrive.IsReady == true &&
                    loadedDrive.DriveType == System.IO.DriveType.Removable)
                    d.Add(loadedDrive);
            }
            return d;
        }
    }
}
