namespace KPZ_lab4.Mediator;

class CommandCentre
{
    private readonly List<Runway> runways = new();
    private readonly Dictionary<Aircraft, Runway> aircraftRunways = new();

    public void AddRunway(Runway runway)
    {
        runways.Add(runway);
    }

    public void LandAircraft(Aircraft aircraft)
    {
        Runway? freeRunway = runways.FirstOrDefault(r => !r.IsBusy);

        if (freeRunway == null)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} cannot land. All runways are busy.");
            return;
        }

        freeRunway.MarkBusy();
        aircraftRunways[aircraft] = freeRunway;

        Console.WriteLine($"Aircraft {aircraft.Name} has landed on runway {freeRunway.Id}.");
    }

    public void TakeOffAircraft(Aircraft aircraft)
    {
        if (!aircraftRunways.ContainsKey(aircraft))
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is not on any runway.");
            return;
        }

        Runway runway = aircraftRunways[aircraft];

        runway.MarkFree();
        aircraftRunways.Remove(aircraft);

        Console.WriteLine($"Aircraft {aircraft.Name} has taken off from runway {runway.Id}.");
    }
}