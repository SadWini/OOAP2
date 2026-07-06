using System;
using System.Reflection;
using System.Text.Json;

namespace OOAP_Course2
{
    // класс General, по контракту закрыт для изменений.
    public abstract class General : object
    {
        internal General() 
        { 
        }

        // копирование
        public virtual void CopyTo(General target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (this.GetType() != target.GetType()) throw new ArgumentException("Типы должны совпадать для копирования.");

            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in properties)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(target, prop.GetValue(this));
                }
            }
        }

        // клонирование
        public virtual General Clone()
        {
            string json = Serialize();
            return (General)JsonSerializer.Deserialize(json, this.GetRealType());
        }

        // сравнение
        public virtual bool IsDeepEqual(General other)
        {
            if (other == null) return false;
            if (this.GetRealType() != other.GetRealType()) return false;
            
            return this.Serialize() == other.Serialize();
        }

        // сериализация
        public virtual string Serialize()
        {
            return JsonSerializer.Serialize(this, this.GetRealType());
        }

        // десериализация
        public static T Deserialize<T>(string data) where T : General
        {
            return JsonSerializer.Deserialize<T>(data);
        }

        public virtual void Print()
        {
            Console.WriteLine($"[Type: {this.GetRealType().Name}] State: {Serialize()}");
        }

        // проверка типа
        public bool IsTypeOf(Type targetType)
        {
            if (targetType == null) return false;
            return targetType.IsInstanceOfType(this); 
        }

        // получение типа
        public Type GetRealType()
        {
            return this.GetType(); 
        }
    }


    // открытый класс Any
    public abstract class Any : General
    {
    public Any() : base() 
    { 
    }
    }
}