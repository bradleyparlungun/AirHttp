using System;
using System.Net;

namespace SteamHttp
{
    public class SteamHttpResponse<T>
    {
        private T _value;

        private SteamHttpResponse()
        {}

        internal static SteamHttpResponse<T> CreateFaultedResponse(Exception e)
        {
            return new SteamHttpResponse<T>
            {
                RequestFaulted = true,
                InnerException = e
            };
        }

        internal static SteamHttpResponse<T> CreateSuccessResponse(HttpStatusCode statusCode, T responseObject)
        {
            return new SteamHttpResponse<T>
            {
                RequestFaulted = false,
                StatusCode = statusCode,
                Value = responseObject
            };
        }

        public HttpStatusCode StatusCode{ get; private set; }

        public bool RequestFaulted{ get; private set; }
        public Exception InnerException{ get; private set; }

        public T Value 
        {
            get
            {
                if(RequestFaulted)
                {
                    throw InnerException;
                }
                else
                {
                    return _value;
                }
            }
            private set
            {
                _value = value;
            }
        }
    }
}