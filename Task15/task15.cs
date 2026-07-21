namespace OOAP_Course2
{
    public abstract class Enemy
    {
        public string Name { get; protected set; }

        protected Enemy(string name)
        {
            Name = name;
        }

        public abstract void Attack();
    }

    public class MeleeEnemy : Enemy
    {
        public MeleeEnemy(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} наносит удар мечом");
        }
    }

    public class RangedEnemy : Enemy
    {
        public RangedEnemy(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} выпускает стрелу");
        }
    }

    public class KamikazeEnemy : Enemy
    {
        public KamikazeEnemy(string name) : base(name) { }

        public override void Attack()
        {
            Console.WriteLine($"{Name} подбегает и взрывается!");
            Die();
        }

        private void Die() { /* ... */ }
    }
}