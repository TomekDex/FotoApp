using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Models;
using FotoApp.Schell;
using FotoApp.ViewModels.Actions;

namespace FotoApp.ViewModels
{
    public class ListFotoViewModel :PropertyChangedBase, ISchellable
    {
        #region Propertis;
        public SchellViewModel Schell { get; set; }
        private GetFotoViewModel getFoto;

        private BindableCollection<Data> _fotoData;
        public BindableCollection<Data> FotoData {
            get { return _fotoData; }
            set
            {
                _fotoData = value;
                NotifyOfPropertyChange(()=> FotoData );
            }
        }
        #endregion
       
        #region Constractor
        public ListFotoViewModel(SchellViewModel schellViewModel, GetFotoViewModel getFotoViewModel)
        {
            Schell = schellViewModel;
            getFoto = getFotoViewModel;
            getFoto.FotoCollection = new FinalColection();
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
                     index = 1
                 },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 2
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 3
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 4
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 5
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 6
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 7
                },
                new Data
                {
                    bitmap =
                        new BitmapImage(
                            new Uri(@"C:\Users\Marcin Gajda\OneDrive\Project\Baza\Baza\Resources\IMG_8903.JPG",
                                UriKind.Absolute)),
                    index = 8
                }
            };
        }
#endif
        public void ActiveChechBox(object itemBox)
        {
            var tmp = itemBox as Data;

            Uri uri = null;

            if (tmp?.Chekerd == true)
            {
                uri = tmp.bitmap.UriSource;
                var foto = new FinalFoto
                {
                    NumbersOFFoto = 1,
                    Urifoto = uri
                };
                getFoto.FotoCollection.FotoColection.Add(foto);
            }

            // przekazuje do kopiowania
            var copyFoto = new CopyFoto();
            copyFoto.CopyFotoToLocal(uri);
        }


        #endregion

    }
}
