using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Actions
{
    public class NewDirectory
    {

        string path, directoryname;

        public NewDirectory()
        {

            CreateDirectory(path,directoryname);
            
        }

        public string CreateDirectory(string path, string directoryname)
        {

           string newpath = path + directoryname;
           string nameDirectory = Directory.CreateDirectory(newpath).ToString();

            return nameDirectory;
        }
        
    }
}
