using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Kate", 1990, Person.Sex.Female);
            Person.Serialize(p1);
            Person p2 = new Person("Tony", 1985, Person.Sex.Male);
            Person.Serialize(p2);

            Console.WriteLine("Deserialized person: " + Person.Deserialize());

            Console.ReadKey();
        }
    }
}
