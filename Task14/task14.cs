namespace OOAP_Course2
{
    public abstract class General { }

    public interface IAddable<T>
    {
        T Add(T other);
    }

    public class Vector<T> : General, IAddable<Vector<T>> 
        where T : General, IAddable<T>
    {
        public T[] Items { get; }

        public Vector(T[] items)
        {
            Items = items;
        }

        public Vector<T> Add(Vector<T> other)
        {
            if (other == null || this.Items.Length != other.Items.Length)
            {
                return null; 
            }

            T[] resultItems = new T[this.Items.Length];
            for (int i = 0; i < this.Items.Length; i++)
            {
                resultItems[i] = this.Items[i].Add(other.Items[i]);
            }

            return new Vector<T>(resultItems);
        }
    }

    public class MyNumber : General, IAddable<MyNumber>
    {
        public int Value { get; }
        public MyNumber(int value) { Value = value; }

        public MyNumber Add(MyNumber other) => new MyNumber(this.Value + other.Value);
        public override string ToString() => Value.ToString();
    }

    public class Program
    {
        public static void Main()
        {
            MyNumber n1 = new MyNumber(1);
            MyNumber n2 = new MyNumber(2);
            MyNumber n3 = new MyNumber(3);
            MyNumber n4 = new MyNumber(4);

            Vector<MyNumber> v1 = new Vector<MyNumber>(new[] { n1, n2 });
            Vector<MyNumber> v2 = new Vector<MyNumber>(new[] { n3, n4 });

            var deepVec1 = new Vector<Vector<Vector<MyNumber>>>(new[] 
            { 
                new Vector<Vector<MyNumber>>(new[] { v1 }) 
            });
            
            var deepVec2 = new Vector<Vector<Vector<MyNumber>>>(new[] 
            { 
                new Vector<Vector<MyNumber>>(new[] { v2 }) 
            });

            Console.WriteLine("Выполняем сложение Vector<Vector<Vector<MyNumber>>>...");
            
            var result = deepVec1.Add(deepVec2);

            if (result != null)
            {
                Console.WriteLine("Проверяем результаты сложения");
                Console.WriteLine($"Результат: {result.Items[0].Items[0].Items[0].Value}, {result.Items[0].Items[0].Items[1].Value}");
            }
        }
    }
}