namespace KPZ_lab4.Observer;

class EventListener
{
    private Action handler;

    public EventListener(Action handler)
    {
        this.handler = handler;
    }

    public void Execute()
    {
        handler();
    }
}