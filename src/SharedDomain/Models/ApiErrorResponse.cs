using SharedDomain.Models.Interface;
using SharedDomain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomain.Models
{
    public class ApiErrorResponse : IApiErrorResponse
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public bool Success { get; } = false;
        public int StatusCode { get; }
        public ApiErrorResponse(List<string> errors, int statusCode = 500)
        {
            Errors = errors;
            this.StatusCode = statusCode;
        }

        public ApiErrorResponse(string error, int statusCode = 500)
        {
            Errors.Add(error);
            this.StatusCode = statusCode;
        }

    }
}
