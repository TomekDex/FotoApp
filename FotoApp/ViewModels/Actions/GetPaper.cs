﻿using System.Collections.Generic;
using Caliburn.Micro;
using FotoApp.Pref;
using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;

namespace FotoApp.ViewModels.Actions
{
    public class GetPapers
    {
        private readonly List<Types> _listTypes;
        private List<Sizes> _listSizes;

        private readonly FotoAppRAll _all = FotoAppRAll.Ins;

        public GetPapers()
        {
            _listTypes = _all.Types.GetAll(true);
        }

        public BindableCollection<Models.ChangePapersAnSiseModel.Types> GetTypes()
        {
            var tmp = new BindableCollection<Models.ChangePapersAnSiseModel.Types>();
            foreach (var e in _listTypes)
            {
                var tmpType = new Models.ChangePapersAnSiseModel.Types();
                tmpType.id = e.TypeID;
                try
                {
                    tmpType.Type = _all.TypeTexts.GetTypeTextByTypeALang(e, new Languages {Language = Preference.Lang}).Text;
                }
                catch (NotExistInDataBaseException)
                {
                    tmpType.Type = "Tymczasowy text";
                }
                tmp.Add(tmpType);
            }
            return tmp;
        }

        public Types GetTypeByIndex(int index)
        {
            return _listTypes[index - 1];
        }
        public BindableCollection<Models.ChangePapersAnSiseModel.SizeM> GetSizesByType(Types type)
        {
            
            _listSizes = _all.Sizes.GetSizesByType(type);
            var tmp = new BindableCollection<Models.ChangePapersAnSiseModel.SizeM>();
            foreach (var e in _listSizes)
            {
                var tmpSizes = new Models.ChangePapersAnSiseModel.SizeM
                {
                    Height = e.Height,
                    Width = e.Width,
                    SizeText = _all.SizeTexts.GetSizeTextBySizeALang(e, new Languages {Language = Preference.Lang}).Text
                };

                tmp.Add(tmpSizes);
            }
            return tmp;
        }

        private Models.ChangePapersAnSiseModel.SizeM GetSizes()
        {
            var defSize = new Models.ChangePapersAnSiseModel.SizeM();
            var tmpSizes = GetSizesByType(GetTypeByIndex(1));
            defSize.Width = tmpSizes[0].Width;
            defSize.Height = tmpSizes[0].Height;
            return defSize;
        }

        public static Papers GetDefaultPaper()
        {
            var papers = new Papers();
            papers.TypeID = 1;
            papers.Height = 900;
            papers.Width = 1300;
            return papers;
        }
    }
}

