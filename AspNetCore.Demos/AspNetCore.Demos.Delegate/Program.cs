using System;

namespace AspNetCore.Demos.Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyApplicationBuilder builder = new MyApplicationBuilder();
            builder.Use(test => (context) => { Console.WriteLine(1);  return 1; });
            builder.Use(test => (context) => { Console.WriteLine(2); return 2; });
            builder.Run();
        }
    }
}
