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

        public DriveInfo[] GetDriveType()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

           return allDrives;
        }

    }
}
