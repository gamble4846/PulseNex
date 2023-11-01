namespace PulseNex.Model
{
    public class APIResponse
    {
        public ResponseCode Code { get; set; }

        public string Message { get; set; }

        public dynamic Document { get; set; }

        public APIResponse()
        {
        }

        public APIResponse(ResponseCode code, string message, dynamic data = null)
        {
            Code = code;
            Message = message;
            Document = data;
        }
        public enum ResponseCode
        {
            ERROR,
            SUCCESS
        }
    }
}
