namespace KPZ_lab4.ChainOfResponsibility;

class TechnicalSupportHandler : SupportHandler
{
    public override bool HandleRequest(int choice)
    {
        if (choice == 2)
        {
            Console.WriteLine("Technical Support: допомога з технічними проблемами.");
            return true;
        }

        if (nextHandler != null)
        {
            return nextHandler.HandleRequest(choice);
        }

        return false;
    }
}