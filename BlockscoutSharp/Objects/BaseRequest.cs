using System;
using System.Collections.Generic;
using System.Text;

namespace BlockscoutSharp.Objects
{
    public class BaseRequest<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
        public RequestStatus Status { get; set; }
    }

    public enum RequestStatus
    {
        ERROR = 0, OK = 1
    }
}