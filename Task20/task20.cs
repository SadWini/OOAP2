using System;
using System.Collections.Generic;

namespace OOAP_Course2
{
    // наследование вариаций
    public class BaseLogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine($"[INFO]: {message}");
        }
    }

    public class ErrorLogger : BaseLogger
    {
        public override void Log(string message)
        {
            Console.WriteLine($"[CRITICAL ERROR]: {message.ToUpper()}");
        }
    }

    // наследование с конкретизацией
    public abstract class DataExporter
    {
        public abstract void ExportData(string data);
    }

    public class JsonExporter : DataExporter
    {
        public override void ExportData(string data)
        {
            Console.WriteLine($"Экспорт в формате JSON: {{ 'data': '{data}' }}");
        }
    }

    // структурное наследование
    public class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(Player other)
        {
            if (other == null) return 1;
            return this.Score.CompareTo(other.Score);
        }
    }
}