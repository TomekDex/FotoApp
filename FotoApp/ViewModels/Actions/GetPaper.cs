using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using FotoApp.Models.ChangePapersAnSiseModel;
using FotoApp.Pref;
using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using Types = FotoAppDB.DBModel.Types;

namespace FotoApp.ViewModels.Actions
{
    public class GetPapers
    {
        private List<Types> _listTypes;
        private List<Sizes> _listSizes;

        private readonly FotoAppRAll _all = FotoAppRAll.Ins;

        public GetPapers()
        {
            _listSizes = _all.Sizes.GetAll(true);
        }

        public BindableCollection<Models.ChangePapersAnSiseModel.Types> GetTypesBySize(Sizes size)
        {
            _listTypes = _all.Types.GetTypesBySize(size).ToList();
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

        public Sizes GetSizeByIndex(int index)
        {
            return _listSizes[index - 1];
        }
        public BindableCollection<SizeM> GetSizes()
        {
            var tmp = new BindableCollection<SizeM>();
            foreach (var e in _listSizes)
            {
                var tmpSizes = new SizeM
                {
                    Height = e.Height,
                    Width = e.Width,
                    SizeText = _all.SizeTexts.GetSizeTextBySizeALang(e, new Languages {Language = Preference.Lang}).Text
                };
                tmp.Add(tmpSizes);
            }
            return tmp;
        }

        private Models.ChangePapersAnSiseModel.Types GetTypes()
        {
            var defType = new Models.ChangePapersAnSiseModel.Types();
            var tmpType = GetTypesBySize(GetSizeByIndex(1));
            defType.Type = tmpType[0].Type;
            defType.id = tmpType[0].id;
            return defType;
        }
        private Models.ChangePapersAnSiseModel.Types GetSize()
        {
            var defType = new Models.ChangePapersAnSiseModel.Types();
            var tmpType = GetTypesBySize(GetSizeByIndex(1));
            defType.Type = tmpType[0].Type;
            defType.id = tmpType[0].id;
            return defType;
        }

        public static Papers GetDefaultPaper()
        {
            var papers = new Papers();
            papers.TypeID = 1;
            papers.Height = 1300;
            papers.Width = 900;
            return papers;
        }
    }
}

