using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FotoApp.ViewModels.Actions
{
    public class LoadFoto
    {
        private List<string> _listFile;
        private readonly string _fileType1;
        private readonly string _fileType2;
        private readonly string _fileType3;
        private readonly string _fileType4;

        public List<string> ListFile
        {
            get { return _listFile; }
        }

        public LoadFoto( string fileType1, string fileType2, string fileType3, string fileType4)
            : this( fileType1, fileType2, fileType3)
        {
            _fileType4 = fileType4;
        }

        public LoadFoto(  string fileType1, string fileType2, string fileType3)
            : this( fileType1, fileType2)
        {
            _fileType3 = fileType3;
        }

        public LoadFoto(  string fileType1, string fileType2) 
            : this( fileType1)
        {
            _fileType2 = fileType2;
        }

        public LoadFoto(  string fileType1)
        {
            _listFile = new List<string>();
             _fileType1 = fileType1;
        }

        public void GetDirectoryType(string path)
        {
            GetFile(path, _fileType1);
            if (! string.IsNullOrWhiteSpace(_fileType2))
                GetFile(path, _fileType2);
            if (!string.IsNullOrWhiteSpace(_fileType3))
                GetFile(path, _fileType3);
            if (!string.IsNullOrWhiteSpace(_fileType4))
                GetFile(path, _fileType4);

            try
            {
                var dir = Directory.GetDirectories(path, "*.*");
                foreach (var dirName in dir)
                {
                   // GetDirectoryType(dirName);
                }
            }
            catch (System.Exception)
            {
            }
        }
        private void GetFile(string path, string type)
        {
            try
            {
                var files = System.IO.Directory.GetFiles(path, type);
                foreach (string s in files)
                {
                    _listFile.Add(s);
                }
            }
            catch (System.Exception)
            {
            }
        }
    }
}
