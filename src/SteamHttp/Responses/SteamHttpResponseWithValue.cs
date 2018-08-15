using System;
using System.Net;

namespace SteamHttp.Responses
{
    public class SteamHttpResponse<T> : SteamHttpResponse
    {
        private T _value;

        internal static SteamHttpResponse<T> CreateFaultedResponseWithValue(Exception e)
        {
            return new SteamHttpResponse<T>
            {
                RequestFaulted = true,
                InnerException = e
            };
        }

        internal static SteamHttpResponse<T> CreateSuccessResponseWithValue(HttpWebResponse httpWebRespons, T responseObject)
        {
            return new SteamHttpResponse<T>
            {
                RequestFaulted = false,
                Value = responseObject,
                ServerResponse = httpWebRespons
            };
        }

        public T Value
        {
            get
            {
                if (RequestFaulted)
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