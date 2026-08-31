using Microsoft.AspNetCore.Mvc;
using MySchool.Common;
using System.Text.Json;

namespace MySchool.Helpers
{
    public static class ApiResonseHelpers
    {
        public static ApiResponse<T> Success<T>(
            T data,
            string message = "Success",
            int code = 200)
        {
            return new ApiResponse<T>
            {
                Metadata = new Metadata
                {

                    Success = true,
                    Code = code,
                    Message = message
                },
                Data = data
            };
        }


        public static string ErrorString(string message, int code)
        {
            var response = new ApiResponse<object>
            {
                Metadata = new Metadata
                {
                    Success = false,
                    Code = code,
                    Message = message
                },
                Data = default
            };

            return JsonSerializer.Serialize(response);
        }


        public static ContentResult Error(
        int code,
        string message)
        {
            return new ContentResult
            {
                StatusCode = code,
                ContentType = "application/json",
                Content = ErrorString(
                    message,
                    code)
            };
        }
    }
}

