using System;
using System.Linq;
using MPD.Electio.SDK.NetCore.Error;

namespace Spa.StarterKit.React.Models
{
    public class ApiResult
    {
        public bool IsSuccess;
        public string ErrorMessage;

        internal static ApiResult Success => new ApiResult { IsSuccess = true };

        internal static ApiResult GenericError => Error("An error occurred while processing your request");

        internal static ApiResult Error(string message, params object[] args)
        {
            return new ApiResult { IsSuccess = false, ErrorMessage = String.Format(message, args) };
        }

        internal static ApiResult Error(ApiError error)
        {
            var errorMessage = (error.Details != null && error.Details.Any())
                ? error.Details.Select(it => it.Message).Aggregate((s1, s2) => string.Concat(s1, Environment.NewLine, s2))
                : error.Message;

            return new ApiResult
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
            };
        }
    }
}
