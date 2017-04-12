using System;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FotoAppDB.Repository.Single
{

    public class LanguagesR : FotoAppR<FotoAppDbContext, Languages>, ILanguagesR
    {
        public void CheckAndFixBase()
        {
            void CheckAndFixBase(Languages lang, List<string> list)
            {
                list.Add(lang.Language);
                if (lang.Base != null)
                {
                    if (list.Contains(lang.Base))
                    {
                        FotoAppRAll.Ins.Logs.Add(new Logs() { Area = "Lang", Type = "AutoChange", Date = DateTime.Now, Message = "In Language " + lang.Language + " Changed base from " + lang.Base + " to null" });
                        lang.Base = null;
                        Update(lang);
                    }
                    else
                    {
                        CheckAndFixBase(Context.Language.Find(lang.Base), list);
                    }
                }
            }
            var toCheck = Context.Language.Where(b=> b.Base!=null);
            foreach (Languages s in toCheck)
            {
                List<string> lang = new List<string>();
                CheckAndFixBase(s, lang);
            }
            Save();
        }

        public override Languages Get(Languages FAobject)
        {
            Languages o = Context.Language.Find(FAobject.Language);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
            }
        }

        public override bool Is(Languages FAobject)
        {
            return Context.Language.Find(FAobject.Language) != null;
        }
    }
}
