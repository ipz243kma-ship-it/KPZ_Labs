namespace KPZ_lab4.ChainOfResponsibility;

class BasicSupportHandler : SupportHandler
{
    public override bool HandleRequest(int choice)
    {
        if (choice == 1)
        {
            Console.WriteLine("Basic Support: допомога з базовими питаннями.");
            return true;
        }

        if (nextHandler != null)
        {
            return nextHandler.HandleRequest(choice);
        }

        return false;
    }
}