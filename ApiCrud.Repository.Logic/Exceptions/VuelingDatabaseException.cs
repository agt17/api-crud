using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Repository.Logic.Exceptions
{
    [SerializableAttribute]
    public class VuelingDatabaseException : Exception
    {
        public VuelingDatabaseException()
        {
        }

        public VuelingDatabaseException(string message) : base(message)
        {
        }

        public VuelingDatabaseException(string message, Exception innerException) : 
            base(message, innerException)
        {
        }

        protected VuelingDatabaseException(SerializationInfo info, StreamingContext context) : 
            base(info, context)
        {
        }
    }
}
