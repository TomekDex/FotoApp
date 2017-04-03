using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.Exception
{
    [Serializable()]
    public class OutOfMaxLengthException : System.Exception
    {
        public OutOfMaxLengthException() : base() { }
        public OutOfMaxLengthException(string message) : base(message) { }
        public OutOfMaxLengthException(string message, SystemException inner) : base(message, inner) { }
        protected OutOfMaxLengthException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
