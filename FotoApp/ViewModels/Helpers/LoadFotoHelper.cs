using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;
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
            _path = path;
        }

        public List<string> ActivLoadFoto()
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
            _loadFoto.GetDirectoryType(_path);
            return LoadFoto;
        }

        private void ActivType()
        {
            for (var i = 0; i < _types.Length; i++)
            {
                _types[i] = $"*.{_types[i]}";
            }
        }
        /// <summary>
        /// Pobiera zdiecie z ppodanej striony w arumencie;
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public BindableCollection<Foto> LoadPageFoto(int  page, List<string> listFoto)
        {
            var fotoData = new BindableCollection<Foto>();
            var indexStart = 12 * (page -1);
            var index = 1;
            for (var j = indexStart; j < 12+indexStart && j < listFoto.Count; j++)
            {
                var w = new Foto
                {
                    Index = index++,
                    path = listFoto[j]
                };
                fotoData.Add(w);
                TaskMethod(listFoto[j], w);
                //Task.Factory.StartNew(() => TaskMethod(listFoto[j], w));
            }
            Task.WaitAll();
            return fotoData;
        }
        private void TaskMethod(string tmp, Foto w)
        {
            using (var fs = new FileStream(tmp, FileMode.Open, FileAccess.Read))
            {
                var ms = new MemoryStream();
                var img = new Bitmap(fs);
                var s = img.Height / 300;
                if (s == 0)
                    s = 1;
                var minImg = (Image)new Bitmap(img, img.Width / s, img.Height / s);
                minImg.Save(ms, ImageFormat.Jpeg);
                var bImg = new BitmapImage();
                bImg.BeginInit();
                bImg.StreamSource = new MemoryStream(ms.ToArray());
                bImg.EndInit();
                w.bitmap = bImg;
                fs.Close();
                ms.Close();
            }
        }
    }
}
