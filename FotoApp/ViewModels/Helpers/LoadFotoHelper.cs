using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.Helpers
{
    public class LoadFotoHelper
    {
        private string[] _types;
        private  LoadFoto _loadFoto;
        private readonly string _path;
        public List<string> LoadFoto => _loadFoto.ListFile;

        public LoadFotoHelper(string path)
        {
            ActivLoadFoto();
            _path = path;
            _loadFoto.GetDirectoryType(_path);
        }

        private void ActivLoadFoto()
        {
            _types = Regex.Split(Pref.Preference.TypeFoto, "/");
            ActivType();
            if (_types.Length == 1)
            {
                _loadFoto = new LoadFoto(_types[0]);
            }
            else if (_types.Length == 2)
            {
                _loadFoto = new LoadFoto(_types[0], _types[1]);
            }
            else if (_types.Length == 3)
            {
                _loadFoto = new LoadFoto(_types[0], _types[1], _types[2]);
            }
            else if (_types.Length == 4)
            {
                _loadFoto = new LoadFoto(_types[0], _types[1], _types[2], _types[3]);
            }
            else
            {
                throw  new ToMutchTypesException("Za durzo zdefinoiowanych typów");
            }
        }

        private void ActivType()
        {
            for (var i = 0; i < _types.Length; i++)
            {
                _types[i] = $"*.{_types[i]}";
            }
        }
    }
}
