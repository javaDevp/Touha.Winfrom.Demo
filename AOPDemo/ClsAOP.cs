using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo
{
    public class ClsAOP
    {
        public void Run(Person p)
        {
            Console.WriteLine("Age:{0}, Name:{1}", p.Age, p.Name);
        }

        public bool Validate(Person p)
        {
            if(p == null)
            {
                Console.WriteLine("Invalid Parameter");
                return false;
            }
            return true;
        }
    }
}
