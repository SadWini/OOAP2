using System;

namespace OOAP_Course2
{
    public class Unit
    {
        public string Name { get; }
        public int Health { get; set; }

        public Unit(string name, int health)
        {
            Name = name;
            Health = health;
        }
    }

    public abstract class Cell
    {
        // отношение "содержит" (Has-a).
        protected Unit occupant = null;

        public bool IsOccupied() => occupant != null;

        public virtual void Enter(Unit unit)
        {
            if (!IsOccupied())
            {
                occupant = unit;
                Console.WriteLine($"{unit.Name} зашел на ячейку.");
                ApplyEffect(unit); 
            }
            else
            {
                Console.WriteLine("Ячейка уже занята!");
            }
        }

        public void Leave()
        {
            occupant = null;
        }

        protected abstract void ApplyEffect(Unit unit);
    }

    // наследование - отношение "является" (Is-a).
    public class NormalCell : Cell
    {
        protected override void ApplyEffect(Unit unit)
        {
            Console.WriteLine("Это обычная ячейка без дополнительных эффектов.");
        }
    }

    // пример другой ячейки
    public class HealingCell : Cell
    {
        private int healAmount;

        public HealingCell(int healAmount)
        {
            this.healAmount = healAmount;
        }

        protected override void ApplyEffect(Unit unit)
        {
            unit.Health += healAmount;
            Console.WriteLine($"Ячейка излечила {unit.Name} на {healAmount} ХП. Текущее здоровье: {unit.Health}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Unit player = new Unit("Рыцарь", 100);

            // полиморфизм
            Cell[] path = new Cell[] 
            {
                new NormalCell(),
                new HealingCell(20)
            };

            Console.WriteLine("--- Шаг 1 ---");
            path[0].Enter(player); 
            path[0].Leave();

            Console.WriteLine("\n--- Шаг 2 ---");
            path[1].Enter(player); 
        }
    }
}