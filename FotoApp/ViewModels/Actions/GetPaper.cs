using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using FotoAppDB;
using FotoAppDB.DBModel;
using FotoAppDBTest;

namespace FotoApp.ViewModels.Actions
{
    public class GetPapers
    {
        private List<Types> _listTypes;
        private List<Sizes> _listSizes;
        
        private FotoAppRAll all = FotoAppRAll.Ins;

        public GetPapers()
        {
            _listTypes = all.Types.GetAll(true);
        }
        

        public BindableCollection<Models.> GetSizeByType()
        {
            
        }

        public void GetSizeByType(Types type)
        {
            _listSizes = all.Sizes.GetSizesByType(type);
        }
        
    }
}

