namespace Exercise2;

public class Ship
{
    public string Name { get; }
    public double MaxWeight { get; }
    public int MaxContainers { get; }
    public double MaxSpeed { get; }
    private readonly List<Container> _containers = new();

    public Ship(string name, double maxWeight, int maxContainers, double maxSpeed)
    {
        Name = name;
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        MaxSpeed = maxSpeed;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainers)
        {
            throw new InvalidOperationException("Cannot load container. Maximum number of containers reached.");
        }

        double totalWeight = _containers.Sum(c => c.LoadWeight + c.OwnWeight) + container.LoadWeight + container.OwnWeight;
        if (totalWeight > MaxWeight)
        {
            throw new InvalidOperationException("Cannot load container. Exceeds ship's weight capacity.");
        }

        _containers.Add(container);
    }

    public void LoadContainers(IEnumerable<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            _containers.Remove(container);
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        UnloadContainer(serialNumber);
        LoadContainer(newContainer);
    }

    public void TransferContainerTo(Ship targetShip, string serialNumber)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            UnloadContainer(serialNumber);
            targetShip.LoadContainer(container);
        }
    }

    public override string ToString()
    {
        var info = $"Ship {Name}: Max Speed {MaxSpeed} knots, Max Weight {MaxWeight} tons, Max Containers {MaxContainers}\n";
        info += "Containers:\n" + string.Join("\n", _containers.Select(c => c.ToString()));
        return info;
    }
}