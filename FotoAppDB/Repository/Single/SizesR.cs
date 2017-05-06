using System;
using System.Collections.Generic;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;
using System.Linq;

namespace FotoAppDB.Repository.Single
{
    public class SizesR : FotoAppR<FotoAppDbContext, Sizes>, ISizesR
    {
        public override Sizes Get(Sizes FAobject)
        {
            Sizes o = Context.Size.Find(FAobject.Height, FAobject.Width);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak rozmiaru!");
            }
        }

        public List<Sizes> GetAll(bool available)
        {
            if (available)
            {
                var ids = Context
                .Paper
                .Where(t => t.Availability == null || t.Availability > 0)
                .GroupBy(t => new { t.Height, t.Width })
                .Select(a => new { a.Key.Height, a.Key.Width });
                return Context
                    .Size
                    .Join(ids, s => new { s.Height, s.Width }, b => new { b.Height, b.Width }, (s, b) => new { Sizes = s, Sizes2 = b })
                    .Select(x => x.Sizes)
                    .ToList();
            }
            else
            {
                var hids = Context
                .Paper
                .Where(t => t.Availability == null || t.Availability > 0)
                .GroupBy(t => new { t.Height, t.Width })
                .Select(a => new { a.Key.Height, a.Key.Width });
                var ids = Context
                   .Size
                   .Where(t => !hids.Contains(new { t.Height, t.Width }))
                   .Select(a => new { a.Height, a.Width });
                return Context
                    .Size
                    .Join(ids, s => new { s.Height, s.Width }, b => new { b.Height, b.Width }, (s, b) => new { Sizes = s, Sizes2 = b })
                    .Select(x => x.Sizes)
                    .ToList();
            }
        }

        public List<Sizes> GetSizesByType(Types type)
        {
            var ids = Context
                .Paper
                .Where(p => p.TypeID == type.TypeID)
                .GroupBy(t => new { t.Height, t.Width })
                .Select(a => new { a.Key.Height, a.Key.Width });
            return Context
                    .Size
                    .Join(ids, s => new { s.Height, s.Width }, b => new { b.Height, b.Width }, (s, b) => new { Sizes = s, Sizes2 = b })
                    .Select(x => x.Sizes)
                    .ToList();
        }

        public List<Sizes> GetSizesByType(Types type, bool available)
        {
            if (available)
            {
                var ids = Context
                    .Paper
                    .Where(p => p.TypeID == type.TypeID && (p.Availability == null || p.Availability > 0))
                    .GroupBy(t => new { t.Height, t.Width })
                    .Select(a => new { a.Key.Height, a.Key.Width });
                return Context
                    .Size
                    .Join(ids, s => new { s.Height, s.Width }, b => new { b.Height, b.Width }, (s, b) => new { Sizes = s, Sizes2 = b })
                    .Select(x => x.Sizes)
                    .ToList();
            }
            else
            {
                var hids = Context
                    .Paper
                    .Where(p => p.TypeID == type.TypeID && (p.Availability == null || p.Availability > 0))
                    .GroupBy(t => new { t.Height, t.Width })
                    .Select(a => new { a.Key.Height, a.Key.Width });
                var ids = Context
                   .Paper
                   .Where(t => !hids.Contains(new { t.Height, t.Width }) && t.TypeID == type.TypeID)
                   .Select(a => new { a.Height, a.Width });
                return Context
                    .Size
                    .Join(ids, s => new { s.Height, s.Width }, b => new { b.Height, b.Width }, (s, b) => new { Sizes = s, Sizes2 = b })
                    .Select(x => x.Sizes)
                    .ToList();
            }
        }

        public override bool Is(Sizes FAobject)
        {
            return Context.Size.Find(FAobject.Height, FAobject.Width) != null;
        }
    }
}
