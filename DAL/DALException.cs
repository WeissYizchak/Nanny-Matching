using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAL
{
    [Serializable]
    public class DALException : Exception
    {
        public DALException() : base() { }
        public DALException(string message) : base(message) { }
        public DALException(string message, Exception inner) : base(message, inner) { }
        protected DALException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
