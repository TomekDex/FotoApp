﻿using System;
using FotoApp.Models.FotoColection;
using FotoApp.ViewModels.EvenArgs.Args;
using FotoApp.ViewModels.Exception;

namespace FotoApp.ViewModels.EvenArgs
{
    public class GetFoto
    {
        public delegate void GetFotoDelegate(object sender, EventArgs e);

        public event GetFotoDelegate getFotoDelegate = null;
        /*public void GetFotoColection(object getFoto, FinalFotoColection finalColection)
        {
            var tmp = new GetFotoArgs(finalColection);
            ReservationGetFotoArgs(getFoto, tmp);
        }*/
        private void ReservationGetFotoArgs(object sender, EventArgs e)
        {
            if (sender == null) throw new NullGetFotoException("Brak widoku model");

            if (e == null) throw new NullListFotoException("Brak zdjęć do zamówienia");

            if (null != getFotoDelegate)
            {
                getFotoDelegate(sender, e);
            }
        }
    }
}
