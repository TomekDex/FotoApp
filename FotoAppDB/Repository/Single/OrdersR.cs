using System.Collections.Generic;
using System.Linq;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;
using FotoAppDB.DBModel;
using FotoAppDB.Casing;
using System;

namespace FotoAppDB.Repository.Single
{
    public class OrdersR : FotoAppR<FotoAppDbContext, Orders>, IOrdersR
    {
        public override Orders Get(Orders FAobject)
        {
            Orders o = Context.Order.Find(FAobject.OrderID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono zamowienia");
            }
        }

        public override bool Is(Orders FAobject)
        {
            return Context.Order.Find(FAobject.OrderID) != null;
        }

        public List<OrderRaport> OrderRaport(Orders order)
        {
            return Context
                .OrderFoto
                .Where(o => o.Fotos.OrderID == order.OrderID)
                .Join(Context.Type,
                    a => a.TypeID,
                    b => b.TypeID,
                    (a, b) => new
                    {
                        OrderID = a.Fotos.OrderID,
                        Height = a.Height,
                        Width = a.Width,
                        TypeID = a.TypeID,
                        Quantity = a.Quantity,
                        Connect = b.Connect
                    })
                .GroupBy(a => new
                {
                    OrderID = a.OrderID,
                    Height = a.Height,
                    Width = a.Width,
                    Connect = ((a.Connect == null) ? a.TypeID : a.Connect)
                })
                .Select(a => new
                {
                    OrderID = a.Key.OrderID,
                    Height = a.Key.Height,
                    Width = a.Key.Width,
                    Connect = a.Key.Connect,
                    TypeID = a.Min(b => b.TypeID),
                    Sum = a.Sum(b => b.Quantity)
                })
                .Join(Context.Price,
                    a => a.Height,
                    b => b.Height,
                    (a, b) => new
                    {
                        paper = a,
                        price = b
                    })
                .Where(c =>
                    c.paper.Connect == c.price.TypeID &&
                    c.price.Height == c.paper.Height &&
                    c.paper.Width == c.price.Width &&
                    c.paper.Sum > c.price.Quantity)
                .GroupBy(a => new
                {
                    OrderID = a.paper.OrderID,
                    Height = a.paper.Height,
                    Width = a.paper.Width,
                    Sum = a.paper.Sum,
                    Connect = a.price.TypeID,
                    TypeID = a.paper.TypeID
                })
                .Select(a => new
                {
                    OrderID = a.Key.OrderID,
                    Height = a.Key.Height,
                    Width = a.Key.Width,
                    Sum = a.Key.Sum,
                    Connect = a.Key.Connect,
                    TypeID = a.Key.TypeID,
                    Quantity = a.Max(b => b.price.Quantity)
                })
                .Join(Context.Price,
                    a => a.Height,
                    b => b.Height,
                    (a, b) => new
                    {
                        paper = a,
                        price = b
                    })
                .Where(c =>
                    c.paper.Connect == c.price.TypeID &&
                    c.price.Height == c.paper.Height &&
                    c.paper.Width == c.price.Width &&
                    c.paper.Quantity == c.price.Quantity)
                .Select(a => new
                {
                    OrderID = a.paper.OrderID,
                    TypeID = a.paper.TypeID,
                    Connect = a.paper.Connect,
                    Height = a.paper.Height,
                    Width = a.paper.Width,
                    Price = a.price.Price
                })
                .Join(Context.OrderFoto,
                    a => a.OrderID,
                    b => b.Fotos.OrderID,
                    (a, b) => new
                    {
                        cost = a,
                        fotos = b
                    })
                .Where(a =>
                    a.fotos.Fotos.OrderID == a.cost.OrderID &&
                    a.fotos.Height == a.cost.Height &&
                    a.fotos.Width == a.cost.Width &&
                    (a.cost.Connect == a.fotos.TypeID ||
                    a.cost.TypeID == a.fotos.TypeID))
                .GroupBy(a => new
                {
                    Height = a.fotos.Height,
                    Width = a.fotos.Width,
                    TypeID = a.fotos.TypeID,
                    Price = a.cost.Price,
                    Connect = a.cost.Connect
                })
                .Select(a => new
                {
                    Height = a.Key.Height,
                    Width = a.Key.Width,
                    TypeID = a.Key.TypeID,
                    Price = (Int64)a.Sum(z => z.fotos.Quantity) * (Int64)a.Key.Price,
                    Connect = a.Key.Connect,
                    Quantity = a.Sum(z => z.fotos.Quantity)
                })
                .ToList()
                .Select(a => new OrderRaport()
                {
                    Paper = new Papers()
                    {
                        Height = a.Height,
                        Width = a.Width,
                        TypeID = a.TypeID
                    },
                    Quantity = a.Quantity,
                    Connect = a.Connect,
                    Price = a.Price
                })
                .ToList();
        }
    }
}

//return Context.OrderFoto.Where(o => o.OrderID == order.OrderID)
//    .Join(Context.Type, a => a.TypeID, b => b.TypeID, (a, b) => new { OrderID = a.OrderID, Height = a.Height, Width = a.Width, TypeID = a.TypeID, Quantity = a.Quantity, Connect = b.Connect })
//    .GroupBy(a => new { OrderID = a.OrderID, Height = a.Height, Width = a.Width, Connect = ((a.Connect == null) ? a.TypeID : a.Connect) })
//    .Select(a => new { OrderID = a.Key.OrderID, Height = a.Key.Height, Width = a.Key.Width, Connect = a.Key.Connect, TypeID = a.Min(b => b.TypeID), Sum = a.Sum(b => b.Quantity) })
//    .Join(Context.Price, a => a.Height, b => b.Height, (a, b) => new { paper = a, price = b })
//    .Where(c => c.paper.Connect == c.price.TypeID && c.price.Height == c.paper.Height && c.paper.Width == c.price.Width && c.paper.Sum > c.price.Quantity)
//    .GroupBy(a => new { OrderID = a.paper.OrderID, Height = a.paper.Height, Width = a.paper.Width, Sum = a.paper.Sum, Connect = a.price.TypeID, TypeID = a.paper.TypeID })
//    .Select(a => new { OrderID = a.Key.OrderID, Height = a.Key.Height, Width = a.Key.Width, Sum = a.Key.Sum, Connect = a.Key.Connect, TypeID = a.Key.TypeID, Quantity = a.Max(b => b.price.Quantity) })
//    .Join(Context.Price, a => a.Height, b => b.Height, (a, b) => new { paper = a, price = b })
//    .Where(c => c.paper.Connect == c.price.TypeID && c.price.Height == c.paper.Height && c.paper.Width == c.price.Width && c.paper.Quantity == c.price.Quantity)
//    .Select(a => new { OrderID = a.paper.OrderID, TypeID = a.paper.TypeID, Connect = a.paper.Connect, Height = a.paper.Height, Width = a.paper.Width, Price = a.price.Price })
//    .Join(Context.OrderFoto, a => a.OrderID, b => b.OrderID, (a, b) => new { cost = a, fotos = b })
//    .Where(a => a.fotos.OrderID == a.cost.OrderID && a.fotos.Height == a.cost.Height && a.fotos.Width == a.cost.Width && (a.cost.Connect == a.fotos.TypeID || a.cost.TypeID == a.fotos.TypeID))
//    .GroupBy(a => new { Height = a.fotos.Height, Width = a.fotos.Width, TypeID = a.fotos.TypeID, Price = a.cost.Price, Connect = a.cost.Connect })
//    .Select(a => new { Height = a.Key.Height, Width = a.Key.Width, TypeID = a.Key.TypeID, Price = (Int64) a.Sum(z => z.fotos.Quantity) * (Int64) a.Key.Price, Connect = a.Key.Connect, Quantity = a.Sum(z => z.fotos.Quantity) })
//    .ToList()
//    .Select(a => new OrderRaport() { Paper = new Papers() { Height = a.Height, Width = a.Width, TypeID = a.TypeID }, Quantity = a.Quantity, Connect = a.Connect, Price = a.Price })
//    .ToList();
