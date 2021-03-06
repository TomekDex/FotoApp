﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoApp.Models.Raport;
using FotoApp.ViewModels.Actions;
using FotoAppDB;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels.Helpers
{
    public class RaportHelper
    {
        private BindableCollection<Raport> _raport;
        public BindableCollection<Raport> Raport
        {
            get => _raport;
        }

        private int _totalPrice;
        /// <summary>
        /// Pobiera całkowity koszt zamowienia
        /// </summary>
        public string TotalPrice => $"{_totalPrice / 100:c}";

        public RaportHelper()
        {
            _raport = new BindableCollection<Raport>();
        }
        /// <summary>
        /// generuje rapor zlecenia z końcową ceną
        /// </summary>
        public void CreateRaport()
        {
            var all = FotoAppRAll.Ins;
            var raport = all.Orders.OrderRaport(NewOrder.New_Order.Orders).ToList();
            foreach (var r in raport)
            {
                var s = new Sizes
                {
                    Width = r.Paper.Width,
                    Height = r.Paper.Height
                };
                var t = new Types { TypeID = r.Paper.TypeID };
                var l = new Languages {Language = Pref.Preference.Lang};
                if (r.Quantity != null)
                {
                    var itemRaport = new Raport
                    {
                        Price = $"{r.Price / 100:c}",
                        Quantity = (int) r.Quantity,
                        Type =  all.TypeTexts.GetTypeTextByTypeALang(t, l).Text,
                        Size =  all.SizeTexts.GetSizeTextBySizeALang(s,l).Text
                    };
                    _raport.Add(itemRaport);
                }
                _totalPrice += Convert.ToInt32(r.Price);
            }
        }
    }
}
