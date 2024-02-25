using RatServer.Core.Models;
using System;
using System.Collections.Generic;

namespace RatServer.Core.Exception
{
    [Serializable]
    public class RulesException : System.Exception
    {
        private readonly List<ApiError> _errors;

        public RulesException(string errorMessage, string errorCode)
        {
            _errors = Errors;
            _errors.Add(new ApiError(errorCode, errorMessage, ""));
        }
        public RulesException(string errorMessage, string errorCode, object onObject)
        {
            _errors = Errors;
            _errors.Add(new ApiError(errorMessage, errorCode, onObject));
        }

        public RulesException()
        {
            _errors = Errors;
        }

        public RulesException(List<ApiError> errors)
        {
            _errors = errors;
        }

        public List<ApiError> Errors => _errors ?? new List<ApiError>();
    }
}