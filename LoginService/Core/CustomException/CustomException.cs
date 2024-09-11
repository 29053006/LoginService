using LoginService.Models;

namespace LoginService.Core.CustomException
{
    public class CustomException
    {
        public static void Exist(bool assertion, string message, int status = 400)
        {
            if (!assertion)
            {
                throw new CustomExceptionMessage(ErrorResponse(message), status);
            }
        }
        public static void Isvalid(bool assertion, string message, int status = 400)
        {
            if (!assertion)
            {
                throw new CustomExceptionMessage(ErrorResponse(message), status);
            }
        }

        public static void NotNull(object object1, string message, int status = 400)
        {
            if (object1 == null)
            {
                throw new CustomExceptionMessage(ErrorResponse(message), status);
            }
        }
        public static void IsNullOrEmpty(string str, string message, int status = 400)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new CustomExceptionMessage(ErrorResponse(message), status);
            }
        }
        public static CustomException Exception(string message, int status = 400)
        {
            throw new CustomExceptionMessage(ErrorResponse(message), status);
        }

        private static CustomErrorResponse ErrorResponse(string messageError)
        {
            CustomErrorResponse customErrorResponse = new CustomErrorResponse
            {
                eventItems = new List<CustomErrorItem>
                {
                    new CustomErrorItem
                        {
                            severityCode = "Error",
                            Description = messageError
                        }
                }
            };
            return customErrorResponse;
        }
    }
}
