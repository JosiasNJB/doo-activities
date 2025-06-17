namespace Mediator;

// Crie uma interface IMediator com o método SendMessage().
public interface IMediator
{
    void SendMessage(string message, User sender);
}

public class ChatMediator : IMediator
{
    private readonly List<User> _users = new();

    public void RegisterUser(User user)
    {
        if (!_users.Contains(user))
            _users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.ReceiveMessage(message, sender);
            }
        }
    }
}

// Crie classes User que se comunicam por meio de um ChatMediator.
public class User
{
    public string Name { get; }
    private readonly ChatMediator _mediator;

    public User(string name, ChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
        _mediator.RegisterUser(this);
    }

    public void SendMessage(string message)
    {
        _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message, User sender)
    {
        Console.WriteLine($"{sender.Name} to {Name}: {message}");
    }
}

// Demonstre
class Program
{
    static void Main()
    {
        var mediator = new ChatMediator();

        var user1 = new User("Alice", mediator);
        var user2 = new User("Bob", mediator);

        user1.SendMessage("Hello, Bob!");
        user2.SendMessage("Hi, Alice!");
    }
}
