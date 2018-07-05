using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Ioc.Core
{
    public interface IServiceContainer
    {
        TService Resolve<TService>();

        object Resolve(Type tService);
    }
}
