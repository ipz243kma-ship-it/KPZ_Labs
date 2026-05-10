namespace KPZ_lab4.Mediator;

class Runway
{
    public Guid Id { get; } = Guid.NewGuid();
    public bool IsBusy { get; private set; }

    public void MarkBusy()
    {
        IsBusy = true;
        Console.WriteLine($"Runway {Id} is busy!");
    }

    public void MarkFree()
    {
        IsBusy = false;
        Console.WriteLine($"Runway {Id} is free!");
    }
}