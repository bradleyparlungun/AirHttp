using System;
using System.Net;
using AirHttp.Responses.Interfaces;

namespace AirHttp.Responses.DefferedExtensions
{
    public static class DefferedExtensions
    {
        public static TAirHttpResponse Fail<TAirHttpResponse>(this TAirHttpResponse airHttpResponse,
                                                                        Action<Exception> callback)
                                                                        where TAirHttpResponse : IAirHttpResponse
        {
            if (airHttpResponse.Failed)
            {
                callback(airHttpResponse.FaultException);
            }
            return airHttpResponse;
        }

        public static TAirHttpResponse Success<TAirHttpResponse>(this TAirHttpResponse airHttpResponse,
                                                                        Action<TAirHttpResponse> callback)
                                                                        where TAirHttpResponse : IAirHttpResponse
        {
            if (!airHttpResponse.Failed)
            {
                callback(airHttpResponse);
            }
            return airHttpResponse;
        }

        public static IAirHttpResponse<TValue> Success<TValue>(this IAirHttpResponse<TValue> airHttpResponse,
                                                                        Action<TValue> callback)
        {
            return airHttpResponse.Success(r => callback(r.Value));
        }

        public static TAirHttpResponse Always<TAirHttpResponse>(this TAirHttpResponse airHttpResponse,
                                                                        Action<TAirHttpResponse> callback)
                                                                        where TAirHttpResponse : IAirHttpResponse
        {
            callback(airHttpResponse);
            return airHttpResponse;
        }
    }
}