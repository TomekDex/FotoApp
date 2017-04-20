using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using Caliburn.Micro;
using FotoApp;
using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using FotoAppDBTest;

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
                    tmpType.Type = _all.TypeTexts.GetTypeTextByTypeALang(e, new Languages {Language = "pl_Pl"}).Text;
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
                var tmpSizes = new Models.ChangePapersAnSiseModel.SizeM();

                tmpSizes.Height = e.Height;
                tmpSizes.Length = e.Length;
                tmpSizes.SizeText = _all.SizeTexts.GetSizeTextBySizeALang(e, new Languages { Language = "pl_Pl" }).Text;
                tmp.Add(tmpSizes);
            }
            return tmp;
        }

        private Models.ChangePapersAnSiseModel.SizeM GetSizes()
        {
            var defSize = new Models.ChangePapersAnSiseModel.SizeM();
            var tmpSizes = GetSizesByType(GetTypeByIndex(1));
            defSize.Length = tmpSizes[0].Length;
            defSize.Height = tmpSizes[0].Height;
            return defSize;
        }

        public IEnumerable<object> GetDefaultPaper()
        {
            yield return 1;
            yield return GetSizes();
        }

        public void GetSetings()
        {
            //_all.Settings.CheckLangSettings();
        }

    }
}

