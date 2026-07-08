using System;

namespace OOAP_Course2
{
    public abstract class General
    {
        // в C# методы без модификатора virtual закрыты для переопределения по умолчанию
        public General Clone()
        {
            Console.WriteLine("[General] Выполняется базовая, закрытая логика клонирования.");
            OnCloned(); 
            return this;
        }

        // можем специально открыть метод для расширения потомками через virtual
        protected virtual void OnCloned() 
        { 
        }
    }

    public class Any : General
    {
        protected override void OnCloned()
        {
            Console.WriteLine("[Any] Дополнительная логика: сброс временных кэшей после клонирования.");
        }
    }

    public class SpecificApplicationClass : Any
    {
        // можем переопределить метод, бывший виртуальным, но запретить его расширять потомкам дальше по иерархии через sealed
        protected sealed override void OnCloned()
        {
            Console.WriteLine("[SpecificClass] Финальная логика после клонирования. Дальнейшие переопределения запрещены.");
        }
    }
}