using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Ioc.Core
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; set; }

        public object Instance { get; set; }
    }
}
