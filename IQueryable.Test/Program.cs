using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyQueryable.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<int> a = new List<int> { 3, 4 };



            //if(a.GetType().GetGenericArguments().Length > 0)
            //{
            //    Console.WriteLine(a.GetType().GetGenericArguments()[0]);
            //}
            Expression<Func<int, int, int>> expression = (a, b) => a * b + 2;
            //Queryable<int> s = new Queryable<int>(new QueryProvider());
            //var a = from i in s
            //        where i == 3
            //        select i;
            var myList = new List<String>()
                { "a", "ab", "cd", "bd" }.AsQueryable<String>();

            IQueryable<String> query = from s in myList
                                       where s.StartsWith("a")
                                       select s;

            foreach (String s in query)
            {
                Console.WriteLine(s);
            }

            //var citys = new string[] { "", "", "" };

            //if(citys.Length > 0)
            //{

            //}

            var time = DateTime.Now;
            


            Console.ReadKey();
        }

        
    }
}
