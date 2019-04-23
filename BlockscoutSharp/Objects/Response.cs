using System;
namespace BlockscoutSharp.Objects
{
    public class Response<T>
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