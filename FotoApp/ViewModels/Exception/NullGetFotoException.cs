using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Exception
{
    public class NullGetFotoException : System.Exception
    {
        public NullGetFotoException() :base()
        {
            
        }

        public NullGetFotoException(string message) : base(message)
        {
            
        }
    }
}
