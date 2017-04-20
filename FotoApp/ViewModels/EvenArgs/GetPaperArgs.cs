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
        public SizeM _sizes;

        public GetPaperArgs(int type, SizeM sizes)
        {
            _type = type;
            _sizes = sizes;
        }
    }
}
