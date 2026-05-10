namespace KPZ_lab4.Mediator;

class Aircraft
{
    public string Name { get; }
    private CommandCentre commandCentre;

    public Aircraft(string name, CommandCentre commandCentre)
    {
        Name = name;
        this.commandCentre = commandCentre;
    }

    public void Land()
    {
        Console.WriteLine($"Aircraft {Name} requests landing.");
        commandCentre.LandAircraft(this);
    }

    public void TakeOff()
    {
        Console.WriteLine($"Aircraft {Name} requests take off.");
        commandCentre.TakeOffAircraft(this);
    }
}