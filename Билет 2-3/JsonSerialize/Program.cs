//Напишите метод-расширения для десериализации generic - типа
using System;
using GenericJsonSerializer;

namespace JsonSerialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Sharik", "Dvornyaga");

            var serializedDog = dog.Serialize();

            Console.WriteLine(serializedDog);

            var deserializedDog = serializedDog.Deserialize<Dog>();

            Console.WriteLine(deserializedDog.Name + " " + deserializedDog.Breed);
        }
    }
}
