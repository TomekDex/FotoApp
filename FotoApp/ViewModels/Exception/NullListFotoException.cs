using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Exception
{
    public class NullListFotoException : System.Exception
    {
        public NullListFotoException() : base()
        {
            
        }

        public NullListFotoException(string message) :base(message)
        {
            
        }
    }
}
