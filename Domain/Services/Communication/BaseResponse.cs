namespace SuperMarket.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, string message)
        {
            Success = success; // flag to indicate that the response completed correctly.
            Message = message; // error message if the response is not completed correctly.
        }
    }
}
/*
But if your classes or API s grow frequently avoid using a Base class ,but for this API it's not a huge problem.
 */
