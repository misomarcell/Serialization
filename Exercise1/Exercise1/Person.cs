using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Exercise1
{
    [Serializable]
    class Person
    {
        public enum Sex : int { Male, Female}
        private string name { get; set; }
        private int age { get; set; }
        private Sex sex { get; set; }

        public Person(string _name, int _age, Sex _sex)
        {
            name = _name;
            age = _age;
            sex = _sex;
        }

        public static void Serialize(Person sp)
        {
            // Create file to save the data to 
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization 
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to serialize the data to the file 
            bf.Serialize(fs, sp);

            // Close the file
            fs.Close();
        }
    }   
}
