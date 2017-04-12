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
        //private void CheckLangSettings(Settings langSetting, List<string> lang)
        //{
        //    lang.Add(langSetting.Target);
        //    if (lang.Contains(langSetting.Value))
        //    {
        //        langSetting.Value += "error";
        //        Update(langSetting);
        //        //Save();                
        //    }
        //    else
        //    {
        //        //lang.Add(langSetting.Target);
        //        var next = Context.Setting.Find("lang", langSetting.Value);
        //        if (next != null) CheckLangSettings(next, lang);
        //    }
        //}
        //public void CheckLangSettings()
        //{
        //    foreach (Settings s in Context.Setting.Where(a => a.Area == "lang"))
        //    {
        //        List<string> lang = new List<string>();
        //        CheckLangSettings(s, lang);
        //    }
        //    Save();
        //}

        public void CheckAndFixBase()
        {
            void CheckAndFixBase(Languages lang, List<string> list)
            {
                list.Add(lang.Language);
                if (lang.Base != null)
                {
                    if (list.Contains(lang.Base))
                    {
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
