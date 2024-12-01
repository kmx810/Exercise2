namespace Exercise2;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double maxCapacity, double ownWeight, double height, double depth, double pressure)
        : base("G", maxCapacity, ownWeight, height, depth)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        LoadWeight *= 0.05; // Keep 5% of the load
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD: {message}");
    }
}