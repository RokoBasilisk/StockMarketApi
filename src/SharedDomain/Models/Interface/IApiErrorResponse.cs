using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomain.Models.Interface
{
    public interface IApiErrorResponse : IApiBase
    {
        List<string> Errors { get; }
    }
}
