
using System.Runtime.Serialization;


namespace RatServer.Core.Models
{
    public class ApiResponse
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ApiError Error { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        public ApiResponse(string apiVersion = "1.0.0.0", int statusCode = 200, string message = "Success", object result = null, ApiError apiError = null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
            Error = apiError;
            Version = apiVersion;
        }
    }

}
