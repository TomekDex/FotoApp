using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Exception
{
    public class NullGetPaperExceptin : System.Exception
    {
        public NullGetPaperExceptin() :base()
        {
            
        }

        public NullGetPaperExceptin(string message) :base(message)
        {
            
        }
    }
}
