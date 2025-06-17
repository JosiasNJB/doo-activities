namespace Observer;

// Crie uma interface IObserver com o método Update().
public interface IObserver
{
    void Update(string status);
}

// Implemente classes como EmailNotifier, SmsNotifier, etc.
public class EmailNotifier : IObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"Email: Your order is now {status}.");
    }
}

public class SmsNotifier : IObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"SMS: Your order is now {status}.");
    }
}

public class Order
{
    private readonly List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    public void UpdateStatus(string status)
    {
        Notify(status);
    }

    private void Notify(string status)
    {
        foreach (var observer in _observers)
        {
            observer.Update(status);
        }
    }
}

class Program
{
    static void Main()
    {
        var order = new Order();
        order.Attach(new EmailNotifier());
        order.Attach(new SmsNotifier());

        order.UpdateStatus("Shipped");
    }
}
