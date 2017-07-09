using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Tony", 23, Person.Sex.Male);
            Person.Serialize(p1);

            Console.ReadKey();
        }
    }
}
