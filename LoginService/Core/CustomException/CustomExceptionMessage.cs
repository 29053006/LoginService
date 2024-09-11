using LoginService.Models;

namespace LoginService.Core.CustomException
{
    public class CustomExceptionMessage : Exception
    {
        public CustomErrorResponse ErrorResponse { get; }
        public int StatusCode { get; set; }

        public CustomExceptionMessage(CustomErrorResponse errorResponse, int statusCode)
            : base(errorResponse.eventItems.First().Description)
        {
            ErrorResponse = errorResponse;
            StatusCode = statusCode;
        }
    }
}
