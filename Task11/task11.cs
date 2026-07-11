/*
В C# нет поддержки множественного наследия классов, но можно наследоваться от нескольких интерфейсов
*/

namespace OOAP_Course2
{
    public interface IGeneral 
    { 
        void Print(); 
    }

    public interface IAny : IGeneral 
    { 
    }

    public interface IDocument : IAny 
    { 
        void Sign(); 
    }

    public interface ICharacter : IAny 
    { 
        void Attack(); 
    }

    public class Report : IDocument
    {
        public void Print() => Console.WriteLine("Печать отчета");
        public void Sign() => Console.WriteLine("Отчет подписан");
    }

    public class Warrior : ICharacter
    {
        public void Print() => Console.WriteLine("Профиль воина");
        public void Attack() => Console.WriteLine("Воин атакует");
    }

    public interface INone : IDocument, ICharacter 
    { 
    }

    public class NoneType : INone
    {
        public static readonly NoneType Void = new NoneType();

        private NoneType() {}

        // кидаем ошибку на вызов любого метода
        public void Print() => throw new NullReferenceException("Попытка вызова метода у объекта Void.");
        public void Sign() => throw new NullReferenceException("Попытка вызова метода у объекта Void.");
        public void Attack() => throw new NullReferenceException("Попытка вызова метода у объекта Void.");
    }

    public class Program
    {
        public static void Main()
        {
            IDocument emptyDoc = NoneType.Void;
            ICharacter emptyChar = NoneType.Void;
        }
    }
}
