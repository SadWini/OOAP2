using System;
using System.Collections.Generic;

namespace OOAP_Course2
{
    public class Animal { }
    public class Cat : Animal { }

    public class Program
    {
        public static void Main()
        {   
            IEnumerable<Cat> cats = new List<Cat> { new Cat(), new Cat() };
            IEnumerable<Animal> animals = cats; 
            
            Console.WriteLine("Ковариантность сработала: коллекция котов рассматривается как коллекция животных.");

            Action<Animal> feedAnimal = (animal) => Console.WriteLine("Животное успешно накормлено.");

            Action<Cat> feedCat = feedAnimal;
            
            feedCat(new Cat()); 
        }
    }

    public class AnimalFactory
    {
        public virtual Animal Create() => new Animal();
    }

    public class CatFactory : AnimalFactory
    {
        public override Cat Create() => new Cat();
    }
}