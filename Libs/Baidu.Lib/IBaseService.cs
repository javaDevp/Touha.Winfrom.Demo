using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Lib
{
    public interface IBaseService<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
