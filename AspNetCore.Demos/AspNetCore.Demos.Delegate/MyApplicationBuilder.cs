using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Demos.Delegate
{
    public class MyApplicationBuilder
    {
        public List<Func<MyRequestDelegate, MyRequestDelegate>> middlewares = new List<Func<MyRequestDelegate, MyRequestDelegate>>();

        public MyContext Context = new MyContext();

        public MyRequestDelegate OriginalDelegate;

        public MyApplicationBuilder()
        {
            OriginalDelegate = new MyRequestDelegate(Context =>  1); ;
        }

        public MyApplicationBuilder Use(Func<MyRequestDelegate, MyRequestDelegate> middleware)
        {
            middlewares.Add(middleware);
            return this;
        }

        public void Run()
        {
            foreach(Func<MyRequestDelegate, MyRequestDelegate> middleware in middlewares)
            {
                OriginalDelegate = middleware(OriginalDelegate);
                OriginalDelegate.Invoke(Context);
            }
        }
    }

    public delegate int MyRequestDelegate(MyContext context);

    public class MyContext
    {

    }

    
}
