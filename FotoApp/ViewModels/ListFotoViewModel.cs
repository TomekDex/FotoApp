using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Models.FotoColection;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;
using FotoApp.ViewModels.EvenArgs;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel : ViewModelBase.ViewModelBase, IHandle<IEnumerable<object>>
    {
        
        private readonly GetFotoViewModel _getFoto;

        #region Propertis;

        private BindableCollection<Foto> _fotoData;

        public BindableCollection<Foto> FotoData
        {
            get => _fotoData;
            set
            {
                _fotoData = value;
                NotifyOfPropertyChange(() => FotoData);
            }
        }

        private readonly FinalFotoColection _finalColections;

        private int _type;
        private Sizes _sise;

        #endregion

        #region Constractor

        public ListFotoViewModel(GetFotoViewModel getFoto, IEventAggregator eventAggregator)
            :base(getFoto, eventAggregator)
        {
            _getFoto = getFoto;
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
            _finalColections = new FinalFotoColection();
            _getFoto.FinalColectionDelegat += GetFinalColection;

#if DEBUG
            Inicialice();
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

        public void ActiveChechBox(object itemBox)
        {
            var tmp = itemBox as Foto;

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
                    Type = _type,
                    Size = _sise
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
                _type = (int)list[0];
                _sise = list[1] as Sizes;
            }
        }
        #endregion
    }
}
