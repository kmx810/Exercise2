namespace Exercise2;

public static class Program
{
    public static void Main()
    {
        try
        {
            var ship = new Ship("Oceanic", 50000, 100, 25);
            var liquidContainer = new LiquidContainer(1000, 500, 250, 300, true);
            var gasContainer = new GasContainer(800, 400, 200, 250, 2.5);
            var refrigeratedContainer = new RefrigeratedContainer(1200, 600, 300, 350, "Bananas", -5);

            liquidContainer.Load(400);
            gasContainer.Load(700);
            refrigeratedContainer.Load(1100);

            ship.LoadContainer(liquidContainer);
            ship.LoadContainer(gasContainer);
            ship.LoadContainer(refrigeratedContainer);

            Console.WriteLine(ship);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
