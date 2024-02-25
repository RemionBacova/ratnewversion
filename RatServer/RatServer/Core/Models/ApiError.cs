
namespace RatServer.Core.Models
{
    public class ApiError
    {
        public string message { get; set; }
        public string identifier { get; set; }
        public string code { get; set; }
        public object onObject { get; set; }

        public ApiError()
        {
        }

        public ApiError(string errorMessage,
                            string errorCode,
                            string identifier)
        {
            code = errorCode;
            message = errorMessage;
            this.identifier = identifier;
        }
        public ApiError(string errorMessage, string errorCode, object errorObject)
        {
            code = errorCode;
            message = errorMessage;
            onObject = errorObject;
        }
    }
}
