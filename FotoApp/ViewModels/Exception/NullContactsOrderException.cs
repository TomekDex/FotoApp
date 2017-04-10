using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Exception
{
    public class NullContactsOrderException : System.Exception
    {
        public NullContactsOrderException() :base()
        {
                
        }

        public NullContactsOrderException(string message) : base(message)
        {
            
        }
    }
}
