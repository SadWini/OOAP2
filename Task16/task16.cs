namespace OOAP_Course2
{
    public class Animal 
    { 
        public virtual void Sound() => Console.WriteLine("Звук животного"); 
    }
    
    public class Cat : Animal 
    { 
        public override void Sound() => Console.WriteLine("Мя"); 
    }

    public interface IProducer<out T> 
    { 
        T Produce(); 
    }

    public class AnimalProducer<T> : IProducer<T> where T : new()
    {
        public T Produce() => new T();
    }

    public class Program
    {
        public static void PolymorphicMethod(Animal z)
        {
            Console.Write("Полиморфный вызов: ");
            z.Sound();
        }

        public static void CovariantMethod(IProducer<Animal> producer)
        {
            Console.Write("Ковариантный вызов: ");
            Animal a = producer.Produce(); 
            a.Sound();
        }

        public static void Main()
        {
            Animal myAnimal = new Cat(); 
            PolymorphicMethod(myAnimal);


            IProducer<Cat> catProducer = new AnimalProducer<Cat>();
            
            CovariantMethod(catProducer);
        }
    }
}