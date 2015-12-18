using System;
using System.Runtime.Serialization;

namespace APG.Base
{
    [Serializable]
    public class RangeParametersException<TU> : Exception where TU:IComparable
    {
        public IRange<TU> Range { get; private set; } 
        public RangeParametersException()
        {
        }

        public RangeParametersException(string message, IRange<TU> range) : base(message)
        {
            Range = range;
        }
        public RangeParametersException(string message) : base(message)
        {
        }

        public RangeParametersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RangeParametersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}