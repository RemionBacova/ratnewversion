namespace RatServer.Global.Helpers
{
    public class RewardSystemError
    {
        public int StatusCode
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }

        public RewardSystemError(int statusCode)
        {
            StatusCode = statusCode;
        }

        public RewardSystemError(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;

        }
    }
}
