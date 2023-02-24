using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] animalArguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalArguments[0];
                int age = int.Parse(animalArguments[1]);
                string gender = animalArguments[2];

                try
                {
                    switch (input)
                    {
                        case "Dog":
                            Dog newDog = new Dog(name, age, gender);
                            Console.WriteLine(newDog);
                            break;
                        case "Cat":
                            Cat newCat = new Cat(name, age, gender);
                            Console.WriteLine(newCat);
                            break;
                        case "Frog":
                            Frog newFrog = new Frog(name, age, gender);
                            Console.WriteLine(newFrog);
                            break;
                        case "Kitten":
                            Kitten newKitten = new Kitten(name, age);
                            Console.WriteLine(newKitten);
                            break;
                        case "Tomcat":
                            Tomcat newTomcat = new Tomcat(name, age);
                            Console.WriteLine(newTomcat);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
