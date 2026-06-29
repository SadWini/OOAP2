using System;
using System.Collections.Generic;

namespace OOAP_Course2
{
    // предок
    public class DataExporter
    {
        // метод с динамическим связыванием
        public virtual void Export()
        {
            Console.WriteLine("Выполняется экспорт данных (в текст).");
        }
        
        // метод со статическим связыванием
        public void Connect()
        {
            Console.WriteLine("Подключение к системе.");
        }
    }

    // потомок 1
    public class XmlExporter : DataExporter
    {
        // переопределяем метод предка
        public override void Export()
        {
            Console.WriteLine("Экспорт данных в формате XML.");
        }
    }

    // потомок 2
    public class JsonExporter : DataExporter
    {
        // переопределяем метод предка
        public override void Export()
        {
            Console.WriteLine("Экспорт данных в формате JSON.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // используем динамическое связывание
            List<DataExporter> exporters = new List<DataExporter>
            {
                new DataExporter(),
                new XmlExporter(),
                new JsonExporter()
            };

            Console.WriteLine("--- Демонстрация динамического связывания ---");
            foreach (DataExporter exporter in exporters)
            {
                exporter.Export();
            }
        }
    }
}