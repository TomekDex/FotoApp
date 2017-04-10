using FotoAppDB.Exception;
using FotoAppDB.DBModel;
using FotoAppDB.Repository.Interface;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Single
{
    public class SettingsR : FotoAppR<FotoAppDbContext, Settings>, ISettingsR
    {
        private void CheckLangSettings(Settings langSetting, List<string> lang)
        {
            lang.Add(langSetting.Target);
            if (lang.Contains(langSetting.Value))
            {
                langSetting.Value += "error";
                Update(langSetting);
                //Save();                
            }
            else
            {
                //lang.Add(langSetting.Target);
                var next = Context.Setting.Find("lang", langSetting.Value);
                if (next != null) CheckLangSettings(next, lang);
            }
        }
        public void CheckLangSettings()
        {
            foreach (Settings s in Context.Setting.Where(a => a.Area == "lang"))
            {
                List<string> lang = new List<string>();
                CheckLangSettings(s, lang);                
            }
            Save();
        }

        public override Settings Get(Settings FAobject)
        {
            Settings o = Context.Setting.Find(FAobject.Area, FAobject.Target);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie zdefiniowano ustawien");
            }
        }

        public override bool Is(Settings FAobject)
        {
            return Context.Setting.Find(FAobject.Area, FAobject.Target) != null;
        }
    }
}
