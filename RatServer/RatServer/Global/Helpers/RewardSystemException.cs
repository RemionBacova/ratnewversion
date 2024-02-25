using System;

namespace RatServer.Global.Helpers
{
    [Serializable]
    public class RewardSystemException : Exception
    {
        public int StatusCode
        {
            get; set;
        }

        public RewardSystemException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public RewardSystemException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
