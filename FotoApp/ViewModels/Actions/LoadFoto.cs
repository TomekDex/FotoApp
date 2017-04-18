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

        public LoadFoto(string fileType1, string fileType2, string fileType3, string fileType4)
            : this( fileType1, fileType2, fileType3)
        {
            _fileType4 = fileType4;
        }

        public LoadFoto( string fileType1, string fileType2, string fileType3)
            : this( fileType1, fileType2)
        {
            _fileType3 = fileType3;
        }

        public LoadFoto( string fileType1, string fileType2) : this( fileType1)
        {
            _fileType2 = fileType2;
        }

        public LoadFoto( string fileType1)
        {
            _listFile = new List<string>();
            _fileType1 = fileType1;
        }

        public List<string> ListFile { get; }
        
        public void GetDirectoryOfOneType(string path)
        {
            GetFile(path, _fileType1);
            var dir = Directory.GetDirectories(path, "*.*");
            foreach (var dirName in dir)
            {
                GetDirectoryOfOneType(dirName);
            }
        }
        public void GetDirectoryOfTwoType(string path)
        {
            GetFile(path, _fileType1);
            GetFile(path, _fileType2);
            var dir = Directory.GetDirectories(path, "*.*");
            foreach (var dirName in dir)
            {
                GetDirectoryOfTwoType(dirName);
            }
        }
        public void GetDirectoryOfThreeType(string path)
        {
            GetFile(path, _fileType1);
            GetFile(path, _fileType2);
            GetFile(path, _fileType3);
            var dir = Directory.GetDirectories(path, "*.*");
            foreach (var dirName in dir)
            {
                GetDirectoryOfThreeType(dirName);
            }
        }
        public void GetDirectoryOfForType(string path)
        {
            GetFile(path, _fileType1);
            GetFile(path, _fileType2);
            GetFile(path, _fileType3);
            GetFile(path, _fileType4);
            var dir = Directory.GetDirectories(path, "*.*");
            foreach (var dirName in dir)
            {
                GetDirectoryOfForType(dirName);
            }
        }
        private void GetFile(string path, string type)
        {
            var files = System.IO.Directory.GetFiles(path, type);
            foreach (string s in files)
            {
                _listFile.Add(s);
            }
        }
    }
}
