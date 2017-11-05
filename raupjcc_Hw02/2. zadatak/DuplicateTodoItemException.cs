using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zadatak
{
    [Serializable()]
    public class DuplicateTodoItemException: Exception
    {
        public DuplicateTodoItemException() : base() { }
        public DuplicateTodoItemException(string message) : base(message) { }
        public DuplicateTodoItemException(string message, System.Exception inner) : base(message, inner) { }

        protected DuplicateTodoItemException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
}
