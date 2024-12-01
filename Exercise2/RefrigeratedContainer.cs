namespace Exercise2;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    public RefrigeratedContainer(double maxCapacity, double ownWeight, double height, double depth, string productType, double temperature)
        : base("C", maxCapacity, ownWeight, height, depth)
    {
        ProductType = productType;
        Temperature = temperature;
    }

    public override string ToString()
    {
        return base.ToString() + $", Product Type: {ProductType}, Temperature: {Temperature}°C";
    }
}