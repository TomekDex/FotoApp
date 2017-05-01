using System;
using System.Collections.Generic;
using FotoApp.Const;
using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoApp.Pref.Helpers
{
    public class PreferenceHelper
    {
        private readonly FotoAppRAll _all = FotoAppRAll.Ins;
        
        private const string SPathTarget = "Sciezka";
        private const string SPathArea = "Path";
        private const string STypeTarget = "TypPliku";
        private const string STypeArea = "Type";
        private const string SLangTarget = "en";
        private const string SLangArea = "Lang";
        private const string def = "?";
        /// <summary>
        /// Dodaje nowego setingsa z domyślnym parametrem "?"
        /// </summary>
        /// <param name="area"></param>
        /// <param name="target"></param>
        public void AddSetings(string area, string target)
        {
            
            var settings = new Settings
            {
                Area = area,
                Target = target,
                Value = def
            };
            _all.Settings.AddOrUpdate(settings);
            _all.Settings.Save();
        }
        /// <summary>
        /// Popbiera wartość setingsa podanego w stringu Type, Lang lub Path
        /// </summary>
        /// <param name="Type">Typ setingsa</param>
        /// <returns></returns>
        public string GetSetings(string Type)
        {
            var constS = new ConstStrings();
            var t = $"S{Type}Target";
            var a = $"S{Type}Area";
            var target = (string)constS.GetType().GetField(t).GetValue(this);
            var area = (string)constS.GetType().GetField(a).GetValue(this);
            try
            {
                var tmpSet = new Settings
                {
                    Area = area,
                    Target = target
                };
                var tmp = _all.Settings.Get(tmpSet);
                return tmp.Value;
            }
            catch (NotExistInDataBaseException)
            {
                AddSetings(area, target);
                return "?";
            }
        }
        /// <summary>
        /// ustala nowa wartośc setingsa podanego w stringu  Type, Lang lub Path
        /// </summary>
        /// <param name="Type"> typ setingsa</param>
        /// <param name="value"> wartość zmienianego parametru</param>
        public void UpdateSetings(string Type, string value)
        {
            var constS = new ConstStrings();
            var t = $"S{Type}Target";
            var a = $"S{Type}Area";
            var target = (string)constS.GetType().GetField(t).GetValue(this);
            var area = (string)constS.GetType().GetField(a).GetValue(this);

            var tmpSet = new Settings
            {
                Area = area,
                Target = target
            };
            var tmp = _all.Settings.Get(tmpSet);
            tmp.Value = value;
            _all.Settings.AddOrUpdate(tmp);
            _all.Settings.Save();
        }
    }
}
