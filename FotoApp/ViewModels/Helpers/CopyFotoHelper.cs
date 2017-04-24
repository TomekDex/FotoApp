using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FotoApp.ViewModels.Actions;
using Sundew.Extensions;

namespace FotoApp.ViewModels.Helpers
{
    public class CopyFotoHelper
    {
        private static readonly object O = new object();
        private static CopyFotoHelper _copyFoto;
        private static string _destinationPath;
        private CopyFotoHelper()
        {
            DestinationPath();
        }
        public static CopyFotoHelper CopyFoto
        {
            get
            {
                lock (O)
                {
                    if (null == _copyFoto)
                    {
                        _copyFoto = new CopyFotoHelper();
                    }
                }
                return _copyFoto;
            }
        }

        public void Add(string path)
        {
            Task.Factory.StartNew(() => TaskAction( path));
        }

        private void DestinationPath()
        {
            _destinationPath = NewOrder.New_Order.FinalPath;
        }

        private static void TaskAction( string fromPath)
        {
            var copy = new CopyFoto(_destinationPath);
            copy.CopyFotoToLocal(fromPath);
        }
    }
}
