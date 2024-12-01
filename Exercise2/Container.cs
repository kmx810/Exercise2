namespace Exercise2;

public abstract class Container
{
    private static int _counter = 1;
    public string SerialNumber { get; }
    public double LoadWeight { get; set; }
    public double MaxCapacity { get; }
    public double OwnWeight { get; }
    public double Height { get; }
    public double Depth { get; }

    protected Container(string type, double maxCapacity, double ownWeight, double height, double depth)
    {
        SerialNumber = $"KON-{type}-{_counter++}";
        MaxCapacity = maxCapacity;
        OwnWeight = ownWeight;
        Height = height;
        Depth = depth;
    }

    public virtual void Load(double weight)
    {
        if (LoadWeight + weight > MaxCapacity)
        {
            throw new OverfillException($"Cannot load {weight} kg into container {SerialNumber}. Exceeds maximum capacity.");
        }
        LoadWeight += weight;
    }

    public virtual void Unload()
    {
        LoadWeight = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber}: Load {LoadWeight} kg, Max Capacity {MaxCapacity} kg, Own Weight {OwnWeight} kg";
    }
}