using KPZ_lab4.ChainOfResponsibility;
using KPZ_lab4.Mediator;
using KPZ_lab4.Memento;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Лабораторна робота №4 ===");
            Console.WriteLine("1 - Завдання 1: Chain of Responsibility");
            Console.WriteLine("2 - Завдання 2: Mediator");
            Console.WriteLine("5 - Завдання 5: Memento");
            Console.WriteLine("0 - Вихід");
            Console.Write("Ваш вибір: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RunChainOfResponsibility();
                    break;

                case "2":
                    RunMediator();
                    break;

                case "5":
                    RunMemento();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void RunChainOfResponsibility()
    {
        Console.WriteLine("\n=== Завдання 1: Chain of Responsibility ===");
        var menu = new SupportMenu();
        menu.Start();
    }

    static void RunMediator()
    {
        Console.WriteLine("\n=== Завдання 2: Mediator ===");

        var commandCentre = new CommandCentre();

        var runway1 = new Runway();
        var runway2 = new Runway();

        commandCentre.AddRunway(runway1);
        commandCentre.AddRunway(runway2);

        var aircraft1 = new Aircraft("Boeing 737", commandCentre);
        var aircraft2 = new Aircraft("Airbus A320", commandCentre);
        var aircraft3 = new Aircraft("Antonov AN-225", commandCentre);

        aircraft1.Land();
        aircraft2.Land();
        aircraft3.Land();

        aircraft1.TakeOff();

        aircraft3.Land();
    }

    static void RunMemento()
    {
        Console.WriteLine("\n=== Завдання 5: Memento ===");

        var document = new TextDocument("Початковий текст");
        var editor = new TextEditor(document);
        var history = new History();

        editor.Show();

        history.Save(editor.Save());
        editor.Write("Перша зміна тексту");
        editor.Show();

        history.Save(editor.Save());
        editor.Write("Друга зміна тексту");
        editor.Show();

        var previousState = history.Undo();

        if (previousState != null)
        {
            editor.Restore(previousState);
        }

        editor.Show();

        previousState = history.Undo();

        if (previousState != null)
        {
            editor.Restore(previousState);
        }

        editor.Show();
    }
}