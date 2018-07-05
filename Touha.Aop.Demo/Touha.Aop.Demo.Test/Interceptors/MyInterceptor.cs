using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Aop.Demo.Test.Interceptors
{
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name + " 调用前");
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine(invocation.Method.Name + " 异常");
            }
            finally
            {
                Console.WriteLine(invocation.Method.Name + " 调用后");
            }
        }
    }
}
