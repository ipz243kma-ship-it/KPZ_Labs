namespace KPZ_lab4.ChainOfResponsibility;

abstract class SupportHandler
{
    protected SupportHandler? nextHandler;

    public void SetNextHandler(SupportHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }

    public abstract bool HandleRequest(int choice);
}