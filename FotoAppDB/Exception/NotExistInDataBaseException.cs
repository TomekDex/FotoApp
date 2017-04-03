using System;

namespace FotoAppDB.Exception
{
    [Serializable()]
    public class NotExistInDataBaseException : System.Exception
    {
        public NotExistInDataBaseException() : base() { }
        public NotExistInDataBaseException(string message) : base(message) { }
        public NotExistInDataBaseException(string message, SystemException inner) : base(message, inner) { }
        protected NotExistInDataBaseException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
