using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomain.Models.Interface
{
    public interface IApiBase
    {
        bool Success { get; }

        int StatusCode { get; }

    }
}
