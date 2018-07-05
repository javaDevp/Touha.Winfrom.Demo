using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace Unity_AOP
{
    public class UnityDemo
    {
        public static void Show()
        {
            Users user = new Users()
            {
                Name = "Eleven",
                Password = "123123123123"
            };

            //IUnityContainer  是接口类型  
            IUnityContainer container = new UnityContainer();//声明一个容器  
            //IUnityContainer  是接口类型 UserProcessor是继承该接口的类  
            container.RegisterType<IUserProcessor, UserProcessor>();//声明UnityContainer并注册IUserProcessor  
            //IUnityContainer  是接口类型  其余不需要修改  
            container.AddNewExtension<Interception>().Configure<Interception>()
                .SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());
            //IUnityContainer  是接口类型  
            IUserProcessor userprocessor = container.Resolve<IUserProcessor>();

            Console.WriteLine("********************");
            userprocessor.RegUser(user);//调用  

        }
    }

    public class UserHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            /////自定义代码部分 开始  这部分的代码 会在方法UserProcessor.RegUser 执行前执行  
            Users user = input.Inputs[0] as Users;
            if (user.Password.Length < 10)
            {
                return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
            }
            Console.WriteLine("参数检测无误");

            /////自定义代码部分 结束  
            IMethodReturn methodReturn = getNext.Invoke().Invoke(input, getNext);
            /////自定义代码部分 开始  这部分的代码 会在方法UserProcessor.RegUser 执行后执行  
            /////这里可以写方法  
            /////自定义代码部分 结束  

            return methodReturn;
        }
    }

    public class UserHandlerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new UserHandler() { Order = this.Order };
            return handler;

            //也可以直接下面这种写法  
            //return new UserHandler() { Order = this.Order };  
        }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    /// <summary>  
    /// Order 是执行顺序 排序用的  
    /// </summary>  
    [UserHandlerAttribute(Order = 1)]
    public interface IUserProcessor
    {
        void RegUser(Users user);
    }

    public class UserProcessor : IUserProcessor//MarshalByRefObject,  
    {
        public void RegUser(Users user)
        {
            Console.WriteLine("用户已注册。");
        }
    }
}
