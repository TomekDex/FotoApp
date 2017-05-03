using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using FotoApp.Models.FotoColection;
using FotoApp.Schell;
using FotoAppDB;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels.Helpers
{
    public class OrderFotoDisplayHelper
    {
        private Papers _papers;
        private BitmapImage _image;
        private int _quantity;
        private Fotos _foto;
        /// <summary>
        /// tworzy obraz w liscie zamówien
        /// </summary>
        /// <param name="papers">zdefinowaby apier</param>
        /// <param name="image">obraz</param>
        /// <param name="quantity">ilość</param>
        public OrderFotoDisplayHelper(Papers papers, BitmapImage image, Fotos foto, int quantity)
        {
            _papers = papers;
            _image = image;
            _quantity = quantity;
            _foto = foto;
        }

        public OrderFotoDisplayHelper()
        {
        }
        /// <summary>
        /// Publikuje obraz
        /// </summary>
        public void Publish()
        {
            var or = new OrderFoto();
            var all = FotoAppRAll.Ins;
            or.Type = all.TypeTexts
                .GetTypeTextByTypeALang( new Types {TypeID = _papers.TypeID}, new Languages {Language = Pref.Preference.Lang}).Text;
            or.Size = all.SizeTexts
                .GetSizeTextBySizeALang(new Sizes {Height = _papers.Height, Length = _papers.Length},
                    new Languages {Language = Pref.Preference.Lang}).Text;
            or.Paper = _papers;
            or.Quantity = _quantity;
            or.Image = _image;
            or.Foto = _foto;
            EventAgg.Agregator.EventAggregator.PublishOnCurrentThread(or);
        }
        /// <summary>
        /// modyfikuje obraz
        /// </summary>
        /// <param name="o"></param>
        /// <param name="p"></param>
        /// <param name="quantity"></param>
        public void ModifOrderFoto(OrderFoto o , Papers p, int quantity)
        {
            var all = FotoAppRAll.Ins;
            o.Type = all.TypeTexts
                .GetTypeTextByTypeALang(new Types { TypeID = p.TypeID }, new Languages { Language = Pref.Preference.Lang }).Text;
            o.Size = all.SizeTexts
                .GetSizeTextBySizeALang(new Sizes { Height = p.Height, Length = p.Length },
                    new Languages { Language = Pref.Preference.Lang }).Text;
            o.Paper = p;
            o.Quantity = quantity;
        }
    }
}
