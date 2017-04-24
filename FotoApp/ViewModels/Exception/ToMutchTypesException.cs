using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Exception
{
    class ToMutchTypesException : System.Exception
    {
        public ToMutchTypesException() :base()
        {

        }

        public ToMutchTypesException(string message) : base(message)
        {

        }
    }
}
