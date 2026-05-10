namespace KPZ_lab4.ChainOfResponsibility;

class BillingSupportHandler : SupportHandler
{
    public override bool HandleRequest(int choice)
    {
        if (choice == 3)
        {
            Console.WriteLine("Billing Support: допомога з оплатою.");
            return true;
        }

        if (nextHandler != null)
        {
            return nextHandler.HandleRequest(choice);
        }

        return false;
    }
}