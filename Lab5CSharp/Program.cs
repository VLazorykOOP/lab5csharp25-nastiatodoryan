using System;
using System.Collections.Generic;
using System.Linq;

namespace LabProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Оберіть завдання:");
                Console.WriteLine("1 - Ієрархія класів (Show)");
                Console.WriteLine("2 - Конструктори і деструктори");
                Console.WriteLine("3 - Абстрактний клас Товар + пошук");
                Console.WriteLine("4 - Структура Людина (struct/tuple/record)");
                Console.WriteLine("0 - Вихід");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Task1.Run();
                        break;
                    case "2":
                        Task2.Run();
                        break;
                    case "3":
                        Task3.Run();
                        break;
                    case "4":
                        Task4.Run();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }

    // --- Task 1 ---
    class Toy
    {
        public string Name;
        public void Show() => Console.WriteLine($"Іграшка: {Name}");
    }

    class Product : Toy
    {
        public double Price;
        public new void Show() => Console.WriteLine($"Продукт: {Name}, Ціна: {Price}");
    }

    class Goods : Product
    {
        public string Manufacturer;
        public new void Show() => Console.WriteLine($"Товар: {Name}, Ціна: {Price}, Виробник: {Manufacturer}");
    }

    class Dairy : Goods
    {
        public DateTime Expiry;
        public new void Show() => Console.WriteLine($"Молочний продукт: {Name}, Ціна: {Price}, Виробник: {Manufacturer}, Термін: {Expiry}");
    }

    class Task1
    {
        public static void Run()
        {
            var item = new Dairy { Name = "Молоко", Price = 35, Manufacturer = "Ферма", Expiry = DateTime.Now.AddDays(7) };
            item.Show();
        }
    }

    // --- Task 2 ---
    class ToyWithConstructors
    {
        public ToyWithConstructors() => Console.WriteLine("Конструктор Toy");
        public ToyWithConstructors(string name) => Console.WriteLine($"Toy: {name}");
        ~ToyWithConstructors() => Console.WriteLine("Деструктор Toy");
    }

    class ProductWithConstructors : ToyWithConstructors
    {
        public ProductWithConstructors() => Console.WriteLine("Конструктор Product");
        public ProductWithConstructors(string name, double price) => Console.WriteLine($"Product: {name}, {price}");
        ~ProductWithConstructors() => Console.WriteLine("Деструктор Product");
    }

    class Task2
    {
        public static void Run()
        {
            var obj = new ProductWithConstructors("Іграшка", 100.0);
        }
    }

    // --- Task 3 ---
    abstract class AbstractGoods
    {
        public string Name;
        public double Price;
        public int AgeLimit;

        public abstract void Show();
        public abstract bool IsMatch(string type);
    }

    class ToyItem : AbstractGoods
    {
        public string Material;
        public string Manufacturer;
        public override void Show() =>
            Console.WriteLine($"Іграшка: {Name}, {Price}, {Manufacturer}, {Material}, {AgeLimit}+");

        public override bool IsMatch(string type) => type == "Іграшка";
    }

    class Book : AbstractGoods
    {
        public string Author;
        public string Publisher;
        public override void Show() =>
            Console.WriteLine($"Книга: {Name}, {Author}, {Price}, {Publisher}, {AgeLimit}+");

        public override bool IsMatch(string type) => type == "Книга";
    }

    class Sports : AbstractGoods
    {
        public string Manufacturer;
        public override void Show() =>
            Console.WriteLine($"Інвентар: {Name}, {Price}, {Manufacturer}, {AgeLimit}+");

        public override bool IsMatch(string type) => type == "Інвентар";
    }

    class Task3
    {
        public static void Run()
        {
            AbstractGoods[] items =
            {
                new ToyItem { Name = "М’яч", Price = 120, Manufacturer = "SportCo", Material = "Гума", AgeLimit = 3 },
                new Book { Name = "Казки", Price = 80, Author = "Шевченко", Publisher = "Книголюб", AgeLimit = 5 },
                new Sports { Name = "Ракетка", Price = 300, Manufacturer = "Head", AgeLimit = 10 }
            };

            foreach (var item in items) item.Show();

            Console.WriteLine("\nПошук Іграшок:");
            foreach (var item in items.Where(x => x.IsMatch("Іграшка")))
                item.Show();
        }
    }

    // --- Task 4 ---
    struct Person
    {
        public string LastName, FirstName, MiddleName;
        public string Address, Phone;
        public int Age;

        public void Show() =>
            Console.WriteLine($"{LastName} {FirstName} {MiddleName}, {Age} р., {Phone}, {Address}");
    }

    class Task4
    {
        public static void Run()
        {
            // Структура
            List<Person> people = new List<Person>
            {
                new Person { LastName = "Іванов", FirstName = "Іван", MiddleName = "Іванович", Age = 20, Phone = "111", Address = "Київ" },
                new Person { LastName = "Петренко", FirstName = "Петро", MiddleName = "Петрович", Age = 30, Phone = "222", Address = "Львів" }
            };

            int ageToRemove = 20;
            people.RemoveAll(p => p.Age == ageToRemove);

            string phoneToInsertAfter = "222";
            int index = people.FindIndex(p => p.Phone == phoneToInsertAfter);
            if (index >= 0)
                people.Insert(index + 1, new Person { LastName = "Новий", FirstName = "Олег", MiddleName = "Олегович", Age = 25, Phone = "333", Address = "Харків" });

            foreach (var p in people) p.Show();

            // Кортеж
            (string, int) tuple = ("Олег", 25);
            Console.WriteLine($"\nКортеж: Ім'я = {tuple.Item1}, Вік = {tuple.Item2}");

            // Запис
            var personRecord = new PersonRecord("Олена", "Київ", "999", 22);
            Console.WriteLine($"\nRecord: {personRecord}");
        }

        public record PersonRecord(string Name, string Address, string Phone, int Age);
    }
}




/// <summary>
/// 
/// Top-level statements must precede namespace and type declarations.
/// Оператори верхнього рівня мають передувати оголошенням простору імен і типу.
/// Створення класу(ів) або оголошенням простору імен є закіченням  іструкцій верхнього рівня
/// 
/// </summary>

namespace User
{
    class UserClass
    {
        public string Name { get; set; }
       public  UserClass()
        {
            Name = "NoName";
        }
        UserClass(string n)
        {
            Name = n;
        }
    }

}
class UserClass
{
    public string Name { get; set; }
}