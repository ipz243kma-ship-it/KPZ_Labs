namespace KPZ_lab4.ChainOfResponsibility;

class SupportMenu
{
    public void Start()
    {
        var basic = new BasicSupportHandler();
        var technical = new TechnicalSupportHandler();
        var billing = new BillingSupportHandler();
        var manager = new ManagerSupportHandler();

        basic.SetNextHandler(technical);
        technical.SetNextHandler(billing);
        billing.SetNextHandler(manager);

        while (true)
        {
            Console.WriteLine("\n=== Система підтримки ===");
            Console.WriteLine("1 - Базова підтримка");
            Console.WriteLine("2 - Технічна підтримка");
            Console.WriteLine("3 - Питання оплати");
            Console.WriteLine("4 - Менеджер");
            Console.WriteLine("0 - Вихід");

            Console.Write("Ваш вибір: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0)
            {
                break;
            }

            bool handled = basic.HandleRequest(choice);

            if (!handled)
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            }
        }
    }
}