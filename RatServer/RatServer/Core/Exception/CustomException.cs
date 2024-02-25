using RatServer.Core.Models;
using System;

namespace RatServer.Core.Exception
{
    [Serializable]
    public class CustomException : System.Exception
    {
        private readonly ApiError _apiError = null;

        public ApiError CustomError => _apiError;

        public CustomException(string sMessage, string sCode, string identifier) : base(sMessage)
        {
            _apiError = new ApiError(sMessage, sCode, identifier);
        }
        public CustomException(string sMessage, string sCode, System.Exception innerException) : base(sMessage, innerException)
        {
            _apiError = new ApiError(sMessage, sCode, "");
        }
    }
}