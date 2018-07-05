using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var A = new AopClass();
            A.Hello();

            var aop = new AopClassSub("梦在旅途");
            aop.Pro = "test";
            aop.Output("hlf");
            aop.ShowMsg();
            Console.ReadKey();

        }
    }


    [AopAttribute]
    public class AopClass : ContextBoundObject
    {
        public string Hello()
        {
            return "welcome";
        }

    }


    public class AopClassSub : AopClass
    {
        public string Pro = null;
        private string Msg = null;

        public AopClassSub(string msg)
        {
            Msg = msg;
        }

        public void Output(string name)
        {
            Console.WriteLine(name + ",你好！-->P:" + Pro);
        }

        public void ShowMsg()
        {
            Console.WriteLine($"构造函数传的Msg参数内容是：{Msg}");
        }
    }



    public class AopAttribute : ProxyAttribute
    {
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            AopProxy realProxy = new AopProxy(serverType);
            return realProxy.GetTransparentProxy() as MarshalByRefObject;
        }
    }

    public class AopProxy : RealProxy
    {
        public AopProxy(Type serverType)
            : base(serverType) { }

        public override IMessage Invoke(IMessage msg)
        {
            if (msg is IConstructionCallMessage)
            {
                IConstructionCallMessage constructCallMsg = msg as IConstructionCallMessage;
                IConstructionReturnMessage constructionReturnMessage = this.InitializeServerObject((IConstructionCallMessage)msg);
                RealProxy.SetStubData(this, constructionReturnMessage.ReturnValue);
                Console.WriteLine("Call constructor");
                return constructionReturnMessage;
            }
            else
            {
                IMethodCallMessage callMsg = msg as IMethodCallMessage;
                IMessage message;
                try
                {
                    Console.WriteLine(callMsg.MethodName + "执行前。。。");
                    object[] args = callMsg.Args;
                    object o = callMsg.MethodBase.Invoke(GetUnwrappedServer(), args);
                    Console.WriteLine(callMsg.MethodName + "执行后。。。");
                    message = new ReturnMessage(o, args, args.Length, callMsg.LogicalCallContext, callMsg);
                }
                catch (Exception e)
                {
                    message = new ReturnMessage(e, callMsg);
                }
                Console.WriteLine(message.Properties["__Return"]);
                return message;
            }
        }
    }
}
