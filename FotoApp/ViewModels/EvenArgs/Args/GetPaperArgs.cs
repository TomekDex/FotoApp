using System;
using FotoApp.Models.ChangePapersAnSiseModel;

namespace FotoApp.ViewModels.EvenArgs.Args
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
