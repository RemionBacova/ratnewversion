
using RatServer.Core.Exception;
using RatServer.Global.SystemErrors;
using System;

namespace RatServer.Global.Exceptions
{
    [Serializable]
    public class Auth401Exception : CustomException
    {
        public Auth401Exception(string sMessage, string sCode) : base(sMessage, sCode, CustomSystemErrors.AuthException)
        {

        }
    }
}
