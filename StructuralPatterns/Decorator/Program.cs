namespace Decorator;

// Defina uma interface INotification com o método Send(string message)
public interface INotification
{
    void Send(string message);
}

// Implemente a classe BaseNotification que implementa INotification
public class BaseNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending base notification: {message}");
    }
}

// Crie decoradores como EmailDecorator, SMSDecorator, PushDecorator que também implementam INotification.
public abstract class NotificationDecorator : INotification
{
    protected readonly INotification _wrapped;

    public NotificationDecorator(INotification wrapped)
    {
        _wrapped = wrapped;
    }

    public virtual void Send(string message)
    {
        _wrapped.Send(message);
    }
}

public class EmailDecorator : NotificationDecorator
{
    public EmailDecorator(INotification wrapped) : base(wrapped) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending email: {message}");
    }
}

public class SMSDecorator : NotificationDecorator
{
    public SMSDecorator(INotification wrapped) : base(wrapped) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class PushDecorator : NotificationDecorator
{
    public PushDecorator(INotification wrapped) : base(wrapped) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending push notification: {message}");
    }
}

// Demonstre como você pode compor notificações para enviar mensagens via múltiplos canais.
class Program
{
    static void Main()
    {
    
        INotification notification = new PushDecorator(new SMSDecorator(new EmailDecorator(new BaseNotification())));

        notification.Send("Your order has been shipped!");
    }
}
