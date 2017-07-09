using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Exercise1
{
    [Serializable]
    class Person : IDeserializationCallback, ISerializable
    {
        public enum Sex : int { Male, Female}
        private string name { get; set; }
        [NonSerialized] private int age;
        private int born { get; set; }
        private Sex sex { get; set; }

        public Person() {}

        public Person(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Born", born);

            name = info.GetString("Name");
            born = info.GetInt16("Born");
            CalculateAge();
        }

        public Person(string _name, int _born, Sex _sex)
        {
            name = _name;
            born = _born;
            sex = _sex;
            CalculateAge();
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

        public static Person Deserialize()
        {
            Person dsp = new Person();

            // Open file to read the data from 
            FileStream fs = new FileStream("Person.Dat", FileMode.Open);

            // Create a BinaryFormatter object to perform the deserialization 
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to deserialize the data
            // from the file 
            dsp = (Person)bf.Deserialize(fs);

            // Close the file 
            fs.Close();

            return dsp;
        }

        public override string ToString()
        {
            return name + "; " + age + "; " + sex;
        }

        void IDeserializationCallback.OnDeserialization(Object sender)
        {
            CalculateAge();
        }

        private void CalculateAge()
        {
            age = DateTime.Now.Year - born;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {}
    }
}
