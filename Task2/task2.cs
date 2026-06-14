using System;

namespace OOAP_Course2
{
    public enum VerificationRegion
    {
        Domestic,
        International
    }

    // базовый класс - внутреннее удостоверение личности
    public class Document
    {
        public string OwnerName { get; protected set; }

        public Document(string ownerName)
        {
            OwnerName = ownerName;
        }

        public virtual void VerifyIdentity(VerificationRegion region)
        {
            switch (region)
            {
                case VerificationRegion.Domestic:
                    Console.WriteLine($"{OwnerName}: Личность подтверждена ({region}).");
                    break;
                default:
                    Console.WriteLine($"{OwnerName}: Отказ. Документ работает только внутри страны.");
                    break;
            }
        }
    }

    // конкретный вид документа (может быть свидетельство о рождении, водительнские права и тд)
    public class Passport : Document
    {
        public bool HasActiveVisa { get; private set; }

        public Passport(string ownerName) : base(ownerName) { }

        public void IssueVisa()
        {
            HasActiveVisa = true;
            Console.WriteLine($"{OwnerName}: Виза успешно выдана.");
        }
    }

    // расширение, работает по всему миру
    public class UniversalID : Document
    {
        public UniversalID(string ownerName) : base(ownerName) { }

        public override void VerifyIdentity(VerificationRegion region)
        {
            switch (region)
            {
                case VerificationRegion.Domestic:
                case VerificationRegion.International:
                    Console.WriteLine($"{OwnerName}: Личность подтверждена (Универсально: {region}).");
                    break;
                default:
                    Console.WriteLine($"{OwnerName}: Отказ. Неизвестный регион.");
                    break;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Document basicDoc = new Document("Иван Иванов");
            Passport passport = new Passport("Анна Смирнова");
            UniversalID universalId = new UniversalID("Петр Петров");

            Console.WriteLine("--- Базовый документ ---");
            basicDoc.VerifyIdentity(VerificationRegion.Domestic);
            basicDoc.VerifyIdentity(VerificationRegion.International);

            Console.WriteLine("\n--- Специализация (Паспорт) ---");
            passport.VerifyIdentity(VerificationRegion.Domestic);
            passport.IssueVisa();

            Console.WriteLine("\n--- Расширение (Универсальное удостоверение) ---");
            universalId.VerifyIdentity(VerificationRegion.Domestic);
            universalId.VerifyIdentity(VerificationRegion.International);
        }
    }
}