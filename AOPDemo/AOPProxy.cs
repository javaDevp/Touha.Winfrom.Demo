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
    public class AOPProxy : RealProxy
    {
        public AOPProxy(Type classToProxy)
            :base(classToProxy)
        {

        }

        public override IMessage Invoke(IMessage msg)
        {
            if(msg is IConstructionCallMessage)
            {
                IConstructionReturnMessage constructionReturnMessage = this.InitializeServerObject((IConstructionCallMessage)msg);
                //RealProxy.SetStubData(this, constructionReturnMessage.ReturnValue);
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
