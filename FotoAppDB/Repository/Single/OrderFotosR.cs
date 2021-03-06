﻿using FotoAppDB.Exception;
using FotoAppDB.DBModel;
using FotoAppDB.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FotoAppDB.Repository.Single
{
    public class OrderFotosR : FotoAppR<FotoAppDbContext, OrderFotos>, IOrderFotosR
    {
        public List<OrderFotos> GetAllFotosInOrder(Orders order)
        {
            return Context
                .OrderFoto
                .Where(a => a.Fotos.OrderID == order.OrderID)
                .ToList();
        }

        public override OrderFotos Get(OrderFotos FAobject)
        {
            OrderFotos o = Context.OrderFoto.Find(FAobject.FotoID, FAobject.Height, FAobject.Width, FAobject.TypeID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono zamowienia");
            }
            
        }

        public override bool Is(OrderFotos FAobject)
        {
            return Context.OrderFoto.Find(FAobject.FotoID, FAobject.Height, FAobject.Width, FAobject.TypeID) != null;
        }

        public List<OrderFotos> GetFotoInOrder(Fotos foto)
        {
            return Context.OrderFoto.Where(a => a.FotoID == foto.FotoID).ToList();
        }
    }
}
