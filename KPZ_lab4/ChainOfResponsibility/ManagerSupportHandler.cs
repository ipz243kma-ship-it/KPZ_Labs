namespace KPZ_lab4.ChainOfResponsibility;

class ManagerSupportHandler : SupportHandler
{
    public override bool HandleRequest(int choice)
    {
        if (choice == 4)
        {
            Console.WriteLine("Manager Support: з'єднання з менеджером.");
            return true;
        }

        if (nextHandler != null)
        {
            return nextHandler.HandleRequest(choice);
        }

        return false;
    }
}