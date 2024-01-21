using SharedDomain.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomain.Models.Response
{
    public interface IApiSuccessResponse<T> : IApiBase
    {

        T Data { get; }
        string Message { get; }
    }
}
