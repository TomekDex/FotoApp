using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoApp.Enum;

namespace FotoApp.Models
{
    public class FinalFoto
    {
        public Uri Urifoto { get; set; }
        public Paper Paper { get; set; }
        public SizeFoto SizeFoto { get; set; }
        public int NumbersOfFoto { get; set; }

        public int Index { get; set; }
    }
}
