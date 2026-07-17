using System;

namespace OOAP_Course2
{
    public class ClassA
    {
        // 1. метод публичен в родительском классе А и публичен в его потомке B;
        public virtual void Method1()
        {
            Console.WriteLine("[ClassA] Method1: Публичный метод.");
        }

        // 2. метод публичен в родительском классе А и скрыт в его потомке B;
        public void Method2()
        {
            Console.WriteLine("[ClassA] Method2: Публичный метод.");
        }

        // 3. метод скрыт в родительском классе А и публичен в его потомке B;
        protected void Method3()
        {
            Console.WriteLine("[ClassA] Method3: Скрытый (protected) метод.");
        }

        // 4. метод скрыт в родительском классе А и скрыт в его потомке B.
        protected virtual void Method4()
        {
            Console.WriteLine("[ClassA] Method4: Скрытый (protected) метод.");
        }
    }

    public class ClassB : ClassA
    {
        public override void Method1()
        {
            Console.WriteLine("[ClassB] Method1: Остался публичным.");
        }

        // в C# нельзя сузить область видимости через override, но можем скрыть через new
        private new void Method2()
        {
            Console.WriteLine("[ClassB] Method2: Теперь скрыт (private).");
        }

        // аналогично решаем проблему через new
        public new void Method3()
        {
            Console.WriteLine("[ClassB] Method3: Теперь публичен.");
            base.Method3(); // Вызов оригинальной скрытой логики
        }

        // поддерживается через override с сохранением модификатора
        protected override void Method4()
        {
            Console.WriteLine("[ClassB] Method4: Остался скрытым (protected).");
        }
    }
}