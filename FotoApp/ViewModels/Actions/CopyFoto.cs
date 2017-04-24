using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Actions
{
    public class CopyFoto
    {
        private readonly string _destinationPath;
        public CopyFoto(string destinationPath)
        {
            _destinationPath = destinationPath;
        }

        public void CopyFotoToLocal(string fromPath)
        {
            var fileNeme = Path.GetFileName(fromPath);
            var destFile = Path.Combine(_destinationPath, fileNeme);
            if (!File.Exists(destFile))
            {
                File.Copy(fromPath, destFile);
            }
        }
    }
}
