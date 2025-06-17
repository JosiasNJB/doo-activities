namespace Strategy;

// Crie uma interface IShippingStrategy com o método Calculate().
public interface IShippingStrategy
{
    int Calculate(int distance);
}

// Implemente classes como ExpressShipping, EconomyShipping, etc.
public class EconomyShipping : IShippingStrategy
{
    public int Calculate(int distance)
    {
        return distance / 10;  
    }
}

public class ExpressShipping : IShippingStrategy
{
    public int Calculate(int distance)
    {
        return distance / 4;  // exemplo: 25% do valor da distância
    }
}

public class ShippingCalculator
{
    private IShippingStrategy _strategy;

    public ShippingCalculator(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IShippingStrategy strategy)
    {
        _strategy = strategy;
    }

    public int Calculate(int distance)
    {
        return _strategy.Calculate(distance);
    }
}

class Program
{
    static void Main()
    {
        var calculator = new ShippingCalculator(new EconomyShipping());
        System.Console.WriteLine(calculator.Calculate(100));

        calculator.SetStrategy(new ExpressShipping());
        System.Console.WriteLine(calculator.Calculate(100));
    }
}
