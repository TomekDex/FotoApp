using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Models.ChangePapersAnSiseModel;

namespace FotoApp.ViewModels.EvenArgs
{
    public class GetPaperArgs :EventArgs
    {
        public int _type;

        public SizeM SizeM;

        public GetPaperArgs(int type, SizeM sizeM)

        {
            _type = type;
            SizeM = sizeM;
        }
    }
}
