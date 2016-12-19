namespace Spa.StarterKit.React.Models
{
    public class ApiDataResult<TDataType>
    {
        public TDataType Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public static ApiDataResult<TDataType> Success(TDataType data, string message = null)
        {
            return new ApiDataResult<TDataType>
            {
                Data = data,
                IsSuccess = true,
                Message = message
            };
        }

        public static ApiDataResult<TDataType> Failure(TDataType data, string message = null)
        {
            return new ApiDataResult<TDataType>
            {
                Data = data,
                IsSuccess = false,
                Message = message
            };
        }

        public static ApiDataResult<TDataType> GenericFailure()
        {
            return new ApiDataResult<TDataType>
            {
                Data = default(TDataType),
                IsSuccess = false,
                Message = "An error occurred while processing your request"
            };
        }
    }
}