using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace FotoApp.Schell.Actions
{
    public class ActiveAltCtrlDel
    {
        public static void EnableTaskManager()
        {
            var subKey = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            try
            {
                var regkey = Registry.CurrentUser.CreateSubKey(subKey);
                if (regkey == null) return;
                regkey.DeleteValue("DisableTaskMgr");
                regkey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registry Error!");
            }

        }
    }
}
