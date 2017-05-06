using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.Schell.Actions
{
    public class ActDeActDrive
    {
        #region WMIEvent

        public delegate void InsertCd();
        public delegate void InsertUsb();
        public delegate void InsertCard();

        public event InsertCd insertCD;
        public event InsertUsb insertUSB;
        public event InsertCard insertCard;

        private List<DriveInfo> _cdDriveInfos;
        private List<DriveInfo> _usbDriveInfos;
        private List<DriveInfo> _cardDriveInfos;

        public List<DriveInfo> CdDriveInfos  => _cdDriveInfos;
        public List<DriveInfo> UsbDriveInfos  => _usbDriveInfos; 
        public List<DriveInfo> CardDriveInfos => _cardDriveInfos; 

        public ActDeActDrive()
        {
            AddInsertMemmoryCardHandler();
            AddRemoveMemmoryCardHandler();
            AddInsertUSBHandler();
            AddRemoveUSBHandler();
            AddRemoweInsertCdRomHandler();
        }
        #region Cdrom

        public void AddRemoweInsertCdRomHandler()
        {
            ManagementEventWatcher w = null;
            WqlEventQuery q;
            var observer = new
                ManagementOperationObserver();

            // Bind to local machine
            var opt = new ConnectionOptions();
            opt.EnablePrivileges = true; //sets required privilege
            var scope = new ManagementScope("root\\CIMV2", opt);

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceModificationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 1);

                // DriveType - 5: CDROM
                q.Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5";
                w = new ManagementEventWatcher(scope, q);

                // register async. event handler
                w.EventArrived += Cd;
                w.Start();

                // Do something usefull,block thread for testing
                Console.ReadLine();
            }
            catch (System.Exception)
            {
            }
            finally
            {
                w.Stop();
            }
        }

        #endregion

        #region USB

        public void AddRemoveUSBHandler()
        {
            ManagementEventWatcher w = null;

            WqlEventQuery q;
            var opt = new ConnectionOptions();

            var scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceDeletionEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += USB;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        public void AddInsertUSBHandler()
        {
            ManagementEventWatcher w = null;

            var observer = new ManagementOperationObserver();

            WqlEventQuery q;

            var scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceCreationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_USBControllerdevice'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += USB;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        #endregion

        #region MemmoryCard

        public void AddRemoveMemmoryCardHandler()
        {
            ManagementEventWatcher w = null;

            WqlEventQuery q;
            var opt = new ConnectionOptions();

            var scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceDeletionEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_PhysicalMedia'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += MemmoryCart;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        public void AddInsertMemmoryCardHandler()
        {
            ManagementEventWatcher w = null;

            var observer = new ManagementOperationObserver();

            WqlEventQuery q;
            var opt = new ConnectionOptions();

            var scope = new ManagementScope("root\\CIMV2", opt);
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceCreationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = "TargetInstance ISA 'Win32_PhysicalMedia'";
                w = new ManagementEventWatcher(scope, q);
                w.EventArrived += MemmoryCart;

                w.Start();
            }
            catch (System.Exception)
            {
                if (w != null)
                    w.Stop();
            }
        }

        #endregion

        private void USB(object sender, System.EventArgs e)
        {
            List<string> usbDrivesLetters = new ManagementObjectSearcher("select * from Win32_DiskDrive WHERE InterfaceType='USB'").Get().Cast<ManagementObject>()
                .SelectMany(drive => drive.GetRelated("Win32_DiskPartition").Cast<ManagementObject>())
                .SelectMany(o => o.GetRelated("Win32_LogicalDisk").Cast<ManagementObject>())
                .Select(i => Convert.ToString(i["Name"]) + "\\").ToList();
            _usbDriveInfos =  DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.Removable && usbDrivesLetters.Contains(drive.RootDirectory.Name)).ToList();
            OnInsertUsb();
        }

        private void MemmoryCart(object sender, System.EventArgs e)
        {
            List<string> usbDrivesLetters = new ManagementObjectSearcher("select * from Win32_DiskDrive WHERE InterfaceType='USB'").Get().Cast<ManagementObject>()
                .SelectMany(drive => drive.GetRelated("Win32_DiskPartition").Cast<ManagementObject>())
                .SelectMany(o => o.GetRelated("Win32_LogicalDisk").Cast<ManagementObject>())
                .Select(i => Convert.ToString(i["Name"]) + "\\").ToList();
            List<string> cardDrivesLetters = new ManagementObjectSearcher("select * from Win32_DiskDrive").Get().Cast<ManagementObject>()
                .SelectMany(drive => drive.GetRelated("Win32_DiskPartition").Cast<ManagementObject>())
                .SelectMany(o => o.GetRelated("Win32_LogicalDisk").Cast<ManagementObject>())
                .Select(i => Convert.ToString(i["Name"]) + "\\").ToList();

            foreach (var c in usbDrivesLetters)
            {
                cardDrivesLetters.Remove(c);
            }
            _cardDriveInfos = DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.Removable && cardDrivesLetters.Contains(drive.RootDirectory.Name)).ToList();
            OnInsertCard();
        }

        private void Cd(object sender, EventArrivedEventArgs e)
        {
            _cdDriveInfos = DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.CDRom && drive.IsReady).ToList();
            OnInsertCd();
        }
        #endregion

        public void ActivAll()
        {
            MemmoryCart(null, null);
            Cd(null, null);
            USB(null, null);
        }
        protected virtual void OnInsertCd()
        {
            insertCD?.Invoke();
        }

        protected virtual void OnInsertUsb()
        {
            insertUSB?.Invoke();
        }

        protected virtual void OnInsertCard()
        {
            insertCard?.Invoke();
        }
    }
}
