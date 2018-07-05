using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region In 1 Out 2
            var p = new Program();
            Console.WriteLine("In");
            p.Test1();
            Console.WriteLine("Out");
            Console.ReadKey();
            #endregion
        }

        private async void Test1()
        {
            Console.WriteLine("1");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("2");
        }
    }
}
