using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Actions
{
    public class DriveType
    {
        public DriveType() 
        {
            GetDriveType(); //zwraca wszystkie dyski (nazwa i typ) podłączone do komputera w formie klasy DriveInfo


        }

        static Caliburn.Micro.BindableCollection<DriveInfo> GetDriveType()
        {
            Caliburn.Micro.BindableCollection<DriveInfo> d = new Caliburn.Micro.BindableCollection<DriveInfo>();
            DriveInfo[] loadedDrives = DriveInfo.GetDrives();
            foreach (var loadedDrive in loadedDrives)
            {
                if (loadedDrive.IsReady == true && (loadedDrive.DriveType == System.IO.DriveType.Removable || loadedDrive.DriveType == System.IO.DriveType.CDRom))
                    d.Add(loadedDrive);
            }
            return d;
        }
               
    }
}
