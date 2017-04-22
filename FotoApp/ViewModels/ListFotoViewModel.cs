using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.EvenArgs;
using FotoAppDB;
using FotoAppDB.DBModel;
using Action = System.Action;
using Sizes = FotoApp.Models.ChangePapersAnSiseModel.Sizes;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel : ViewModelBase.ViewModelBase, IHandle<IEnumerable<object>>, IHandle<string>
    {

        private readonly GetFotoViewModel _getFoto;

        public delegate void GetPaperDelegate();

        public event GetPaperDelegate getPaperDelegete = null;

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

        private Foto SetFoto
        {
            set
            {
                FotoData.Add(value);
            }
        }

        public int Type { get; set; }

        public Sizes Sise { get; set; }
       

        private FinalFotoColection _finalColections;

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
            _getFoto.FinalColectionDelegat += GetFinalColection;
            Handle(new GetPapers().GetDefaultPaper());

#if DEBUG
            //Inicialice();
#endif
        }

        #endregion

        #region Action

#if DEBUG

        private void Inicialice()
        {
            FotoData = new BindableCollection<Foto>
            {
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 1
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 2
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 3
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 1
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 2
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 3
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 1
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 2
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 3
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 4
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 5
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 6
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 7
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 8
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 8
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 8
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 8
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 8
                },
                new Foto
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"..\Resources\brak.gif",
                                UriKind.Relative)),
                    Index = 8
                }
            };
        }

#endif

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
            
            if (tmp?.Chekerd == true)
            {

                var uri = tmp.bitmap.UriSource;
                var fileName = Path.GetFileName(uri.ToString());
                var foto = new FinalFoto
                {
                    NumbersOfFoto = 1,
                    Index = tmp.Index,
                    FullPathOfFoto = uri.ToString(),
                    NameOfFoto = fileName,
                };
                _finalColections.FotoColection.Add(foto);
                EventAggregator.PublishOnCurrentThread(true);
                // przekazuje do kopiowania

                var copyFoto = new CopyFoto();
                copyFoto.CopyFotoToLocal(uri);
            }
            else
            {
                var removeTmp = _finalColections.FotoColection.FirstOrDefault(e => tmp != null && e.Index == tmp.Index);
                _finalColections.FotoColection.Remove(removeTmp);
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
                Sise = list[1] as Sizes;
            }
        }

        public void Handle(string message)
        {
            FotoData = new BindableCollection<Foto>();
            Foto f = new Foto();

            

           // Thread t = new Thread(() =>
           //  {
                var d = Application.Current.Dispatcher;
                //Foto f = new Foto();
                  d.BeginInvoke (DispatcherPriority.Normal, new Action( () =>
                {
                    LoadFoto l = new LoadFoto("*.jpg");
                    l.GetDirectoryType(message);


                Task.Factory.StartNew(() => TaskMethod(tmp, w));

                NotifyOfPropertyChange(() => FotoData);
            }
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
        }


                    object i = new object();
                    int index = 1;
                    foreach (var tmp in l.ListFile)
                    {
                        var w = new Foto();
                        var fs = File.Open(tmp, FileMode.Open);
                        var img = new Bitmap(fs);
                        var ms = new MemoryStream();
                        var minImg = img.GetThumbnailImage(200, 200, () => false, IntPtr.Zero);
                        minImg.Save(ms, ImageFormat.Jpeg);
                        var bImg = new BitmapImage();
                        bImg.BeginInit();
                        bImg.StreamSource = new MemoryStream(ms.ToArray());
                        bImg.EndInit();
                        w.bitmap = bImg;
                        w.Index = index++;
                        FotoData.Add(w);
                        fotoData.Add(w);
                        NotifyOfPropertyChange(() => FotoData);
                    }
                }));
           // });
           // t.IsBackground = true;
           // t.Start();


        }
        #endregion
    }
}