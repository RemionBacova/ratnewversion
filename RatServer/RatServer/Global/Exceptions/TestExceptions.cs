
using RatServer.Core.Exception;
using System;

namespace RatServer.Global.Exceptions
{
    [Serializable]
    public class TestNotFoundException : CustomException
    {
        public TestNotFoundException(string sMessage, string sCode) : base(sMessage, sCode, "00009")
        {

        }
    }

    [Serializable]
    public class TestIDInvalidException : CustomException
    {
        public TestIDInvalidException(string sMessage, string sCode) : base(sMessage, sCode, "00010")
        {

        }
    }

    [Serializable]
    public class StandardTypeNotNullException : CustomException
    {
        public StandardTypeNotNullException(string sMessage, string sCode) : base(sMessage, sCode, "00011")
        {

        }
    }
}
