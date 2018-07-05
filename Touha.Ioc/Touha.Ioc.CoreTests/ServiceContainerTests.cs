using Microsoft.VisualStudio.TestTools.UnitTesting;
using Touha.Ioc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Ioc.Core.Tests
{

    public interface IExplicit<TType>
    {
        void Print();
    }

    public class StringExplicit : IExplicit<string>
    {
        public void Print()
        {
            Console.WriteLine("System.String");
        }
    }

    public class IntExplicit : IExplicit<int>
    {
        public void Print()
        {
            Console.WriteLine("System.Int32");
        }
    }

    public class TypeExplicit : IExplicit<Type>
    {
        public void Print()
        {
            Console.WriteLine("System.Type");
        }
    }

    [TestClass()]
    public class ServiceContainerTests
    {

        [TestMethod()]
        public void Test()
        {
            var services = new ServiceContainer();
            services.RegisterForAll(typeof(StringExplicit),
                typeof(IntExplicit), typeof(TypeExplicit));

            services.Resolve<IExplicit<int>>().Print();
            services.Resolve<IExplicit<string>>().Print();
            services.Resolve<IExplicit<Type>>().Print();
        }
    }
}