using SharedDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedDomain.Models
{
    public class ApiSuccessResponse<T> : IApiSuccessResponse<T>
    {
        public bool Success { get; } = true;
        public string Message { get; set; }
        public int StatusCode { get; }
        public T Data { get; }

        [JsonConstructor]
        public ApiSuccessResponse(T data, string message, int statusCode = 200)
        {
            this.Message = message;
            this.StatusCode = statusCode;
            this.Data = data;
        }

        public ApiSuccessResponse(T data, int statusCode = 200)
        {
            this.StatusCode = statusCode;
            this.Data = data;
        }
    }
}
