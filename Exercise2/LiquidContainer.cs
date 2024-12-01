namespace Exercise2;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(double maxCapacity, double ownWeight, double height, double depth, bool isHazardous)
        : base("L", maxCapacity, ownWeight, height, depth)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double allowedCapacity = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

        if (LoadWeight + weight > allowedCapacity)
        {
            NotifyHazard($"Attempted to overload hazardous container {SerialNumber}.");
            throw new OverfillException($"Cannot load {weight} kg into container {SerialNumber}. Exceeds allowed capacity.");
        }

        base.Load(weight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD: {message}");
    }
}