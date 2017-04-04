using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Enum;
using FotoApp.Interface;
using FotoApp.Models;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel :PropertyChangedBase, ISchellable
    {

        public SchellViewModel Schell { get; set; }
        private readonly GetFotoViewModel _getFoto;
        #region Propertis;
        private BindableCollection<Data> _fotoData;
        public BindableCollection<Data> FotoData {
            get { return _fotoData; }
            set
            {
                _fotoData = value;
                NotifyOfPropertyChange(()=> FotoData );
            }
        }

        private FinalColection _finalColections;

        private Paper _paper;
        private SizeFoto _sizeFoto;

        public Paper Paper
        {
            get { return _paper; }
            set
            {
                _paper = value;
                NotifyOfPropertyChange(() => Paper);
            }
        }
        public SizeFoto SizeFoto
        {
            get { return _sizeFoto; }
            set
            {
                _sizeFoto = value;
                NotifyOfPropertyChange(() => SizeFoto);
            }
        }
        #endregion

        #region Constractor
        public ListFotoViewModel(SchellViewModel schellViewModel, GetFotoViewModel getFoto)
        {
            Schell = schellViewModel;
            this._getFoto = getFoto;
            _finalColections = new FinalColection();
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
            FotoData = new BindableCollection<Data>
            {
                new Data
                 {
                     bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                     Index = 1
                 },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 2
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 3
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 4
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 5
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 6
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 7
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    Index = 8
                }
            };
        }
#endif
        public void ActiveChechBox(object itemBox)
        {
            var tmp = itemBox as Data;

            if (tmp?.Chekerd == true)
            {
                var uri = tmp.bitmap.UriSource;
                var foto = new FinalFoto
                {
                    NumbersOfFoto = 1,
                    Index = tmp.Index,
                    Urifoto = uri,
                    Paper = Paper,
                    SizeFoto = SizeFoto
                };
                _finalColections.FotoColection.Add(foto);

                // przekazuje do kopiowania

                var copyFoto = new CopyFoto();
                copyFoto.CopyFotoToLocal(uri);
            }
            else
            {
                var removeTmp = _finalColections.FotoColection.FirstOrDefault(e => tmp != null && e.Index == tmp.Index);
                _finalColections.FotoColection.Remove(removeTmp);
            }
        }

        public FinalColection GetFinalColection()
        {
            return _finalColections;
        }

        #endregion

    }
}
