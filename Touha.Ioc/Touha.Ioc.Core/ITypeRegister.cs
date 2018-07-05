using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Ioc.Core
{
    public interface ITypeRegister
    {
        ITypeRegister RegisterForAll(params Type[] tServices);

        ITypeRegister RegisterForAll(IEnumerable<Type> tServices);

        ITypeRegister RegisterFor(Type tService, params Type[] tInterfaces);

        ITypeRegister RegisterFor(Type tService, IEnumerable<Type> tInterfaces);
    }
}
