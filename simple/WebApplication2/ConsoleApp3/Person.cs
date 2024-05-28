using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract  class Base
    {
         public abstract int Age { get; set; }
    }
    public  class Person:Base
    {
        public string Name { get; set; }
        public override int Age { get; set; }

        public override string ToString()
        {
           return Name+" "+Age;
        }
    }
}
