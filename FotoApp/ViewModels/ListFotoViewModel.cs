using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.EvenArgs;
using FotoAppDB;
using FotoAppDB.DBModel;
using Types = FotoAppDB.DBModel.Types;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel : ViewModelBase.ViewModelBase, IHandle<IEnumerable<object>>, IHandle<string>
    {

        private readonly GetFotoViewModel _getFoto;

        public delegate void GetPaperDelegate();
        public delegate void RefreschView();

        public event GetPaperDelegate getPaperDelegete = null;
        private event RefreschView refresch = null;

        #region Propertis;

        private BindableCollection<Foto> _fotoData;

        public BindableCollection<Foto> FotoData
        {
            get { return _fotoData; }
            set
            {
                _fotoData = value;
                NotifyOfPropertyChange(() => FotoData);
            }
        }

        public int Type { get; set; }

        public SizeM Sise { get; set; }
       

        private FinalFotoColection _finalColections;
        private List<string> _deleteFotoList;
        private NewOrder _newOrder = NewOrder.New_Order;

        public int referszView
        {
            get { return referszView;  }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                referszView = value;
                NotifyOfPropertyChange(() => FotoData);
            }
        }

        #endregion

        #region Constractor

        public ListFotoViewModel(GetFotoViewModel getFoto, IEventAggregator eventAggregator)
            : base(getFoto, eventAggregator)
        {
            _getFoto = getFoto;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
            getPaperDelegete?.Invoke();
            _finalColections = new FinalFotoColection();
            _deleteFotoList = new List<string>();
            _getFoto.FinalColectionDelegat += GetFinalColection;
            Handle(new GetPapers().GetDefaultPaper());

#if DEBUG
            //Inicialice();
#endif
        }

        #endregion

        #region Action


        public void ComboBox()
        {
            
        }
        public void ActiveChechBox(object itemBox)
        {
            FotoAppRAll all = FotoAppRAll.Ins;
            var tmp = itemBox as Foto;
            var paper = new Papers();
            var size = new Sizes
            {
                Height = Sise.Height,
                Length = Sise.Length
            };
            var type = new Types
            {
                TypeID = Type
            };
            paper.Types = type;
            paper.Sizes = size;
            paper.Height = Sise.Height;
            paper.Length = Sise.Length;
            paper.TypeID = Type;

            if (tmp?.Chekerd == true)
            {

                var path = tmp.path;
                var fileName = Path.GetFileName(path);
                var foto = new FinalFoto
                {
                    NumbersOfFoto = 1,
                    Index = tmp.Index,
                    FullPathOfFoto = path,
                    NameOfFoto = fileName,
                };
                _finalColections.FotoColection.Add(foto);
                EventAggregator.PublishOnCurrentThread(true);
                // przekazuje do kopiowania

                var copyFoto = new CopyFoto();
                copyFoto.CopyFotoToLocal(path);
                _deleteFotoList.Remove(path);
            }
            else
            {
                var removeTmp = _finalColections.FotoColection.FirstOrDefault(e => tmp != null && e.Index == tmp.Index);
                _finalColections.FotoColection.Remove(removeTmp);
                if ( 1 == _finalColections.FotoColection.Select(x => tmp != null && x.NameOfFoto == tmp.path).Count())
                    _deleteFotoList.Add(tmp.path);
                EventAggregator.PublishOnCurrentThread(_finalColections.FotoColection.Count != 0);
            }
        }

        public void GetFinalColection()
        {
            var tmp = new GetFoto();
            var hendler = new GetFotoHendler();
            tmp.getFotoDelegate += hendler.GetGoto;
            tmp.GetFotoColection(_getFoto, _finalColections);
        }

        public void Handle(IEnumerable<object> message)
        {
            var list = message.ToList();
            if (list != null)
            {
                Type = (int) list[0];
                Sise = list[1] as SizeM;
            }
        }
        public void Handle(string message)
        {
            FotoData = new BindableCollection<Foto>();
            Foto f = new Foto();

            var l = new LoadFoto("*.jpg");
            l.GetDirectoryType(message);
            var t = l.ListFile;
            var i = new object();
            var index = 1;
            foreach (var tmp in t)
            {
                var w = new Foto
                {
                    Index = index++,
                    path = tmp
                };
                FotoData.Add(w);

                Task.Factory.StartNew(() => TaskMethod(tmp, w));

                NotifyOfPropertyChange(() => FotoData);
            }
        }

        private void refreschView()
        {
            NotifyOfPropertyChange(() => FotoData);
        }
        private void TaskMethod(string tmp, Foto w)
        {
            var fs = File.Open(tmp, FileMode.Open);
            var img = new Bitmap(fs);
            var s = img.Height / 300;
            if (s == 0)
                s = 1;
            var ms = new MemoryStream();
            var minImg = (Image)new Bitmap(img, img.Width / s, img.Height / s);
            minImg.Save(ms, ImageFormat.Jpeg);
            var bImg = new BitmapImage();
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();
            w.bitmap = bImg;
            this.refresch += refreschView;
        }
        
        #endregion
    }
}