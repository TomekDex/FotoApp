using System;
using System.Collections.Generic;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;
using System.Linq;

namespace FotoAppDB.Repository.Single
{
    public class TypesR : FotoAppR<FotoAppDbContext, Types>, ITypesR
    {
        public void CheckAndFixConnect()
        {
            Logs log = new Logs() { Area = "Types", Type = "AutoChange", };
            Console.WriteLine();
            bool fix = false;
            do
            {
                fix = false;
                foreach (Types t in Context.Type)
                {
                    var next = Context.Type.Where(a => a.TypeID == t.Connect).Select(b => b.Connect).SingleOrDefault();
                    if (t.TypeID == t.Connect)
                    {
                        FotoAppRAll.Ins.Logs.Add(new Logs() { Area = "Types", Type = "AutoChange", Date = DateTime.Now, Message = "In Type " + t.TypeID.ToString() + " Changed connect from " + t.Connect.ToString() + " to null" });
                        fix = true;
                        t.Connect = null;
                        Update(t);
                    }
                    else if (next != null && t.Connect != next)
                    {
                        FotoAppRAll.Ins.Logs.Add(new Logs() { Area = "Types", Type = "AutoChange", Date = DateTime.Now, Message = "In Type " + t.TypeID.ToString() + " Changed connect from " + t.Connect.ToString() + " to " + next.ToString() });
                        t.Connect = next;
                        fix = true;
                    }
                }
                Save();
            }
            while (fix);
        }

        public override Types Get(Types FAobject)
        {
            Types o = Context.Type.Find(FAobject.TypeID);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Brak typu!");
            }
        }

        public List<Types> GetAll(bool available)
        {
            if (available)
            {
                var ids = Context
                .Paper
                .Where(t => t.Availability == null || t.Availability > 0)
                .GroupBy(t => t.TypeID)
                .Select(a => new { a.Key });
                return Context
                    .Type
                    .Join(ids, s => s.TypeID, b => b.Key, (s, b) => new { Types = s, TypeID = b })
                    .Select(x => x.Types)
                    .ToList();
            }
            else
            {
                var hids = Context
                .Paper
                .Where(t => t.Availability == null || t.Availability > 0)
                .GroupBy(t => t.TypeID)
                .Select(a => a.Key);
                var ids = Context
                   .Type
                   .Where(t => !hids.Contains(t.TypeID))
                   .Select(a => new { a.TypeID });
                return Context
                    .Type
                    .Join(ids, s => s.TypeID, b => b.TypeID, (s, b) => new { Types = s, TypeID = b })
                    .Select(x => x.Types)
                    .ToList();
            }

        }

        public List<Types> GetTypesBySize(Sizes size)
        {
            var ids = Context
                .Paper
                .Where(p => p.Height == size.Height && p.Length == size.Length)
                .GroupBy(g => g.TypeID)
                .Select(s => new { s.Key });
            return Context
                    .Type
                    .Join(ids, s => s.TypeID, b => b.Key, (s, b) => new { Types = s, TypeID = b })
                    .Select(x => x.Types)
                    .ToList();
        }

        public List<Types> GetTypesBySize(Sizes size, bool available)
        {
            if (available)
            {
                var ids = Context
                    .Paper
                    .Where(p => (p.Height == size.Height && p.Length == size.Length) && (p.Availability == null || p.Availability > 0))
                    .GroupBy(g => g.TypeID)
                    .Select(s => new { s.Key });
                return Context
                    .Type
                    .Join(ids, s => s.TypeID, b => b.Key, (s, b) => new { Types = s, TypeID = b })
                    .Select(x => x.Types)
                    .ToList();
            }
            else
            {
                var hids = Context
                    .Paper
                    .Where(p => (p.Height == size.Height && p.Length == size.Length) && (p.Availability == null || p.Availability > 0))
                    .GroupBy(g => g.TypeID)
                    .Select(s => s.Key);
                var ids = Context
                   .Paper
                   .Where(t => !hids.Contains(t.TypeID) && (t.Height == size.Height && t.Length == size.Length))
                   .Select(a => new { a.TypeID });
                return Context
                    .Type
                    .Join(ids, s => s.TypeID, b => b.TypeID, (s, b) => new { Types = s, TypeID = b })
                    .Select(x => x.Types)
                    .ToList();
            }
        }

        public override bool Is(Types FAobject)
        {
            return Context.Type.Find(FAobject.TypeID) != null;
        }

    }
}
