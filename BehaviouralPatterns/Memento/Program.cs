namespace Memento;

// Crie uma classe Player com propriedades como Position e Health.
public class Player
{
    public int Position { get; set; }
    public int Health { get; set; }

    // Use o padrão Memento para implementar os métodos SaveState() e RestoreState().
    public PlayerMemento SaveState()
    {
        return new PlayerMemento(Position, Health);
    }

    public void RestoreState(PlayerMemento memento)
    {
        Position = memento.Position;
        Health = memento.Health;
    }
}

public class PlayerMemento
{
    public int Position { get; }
    public int Health { get; }

    public PlayerMemento(int position, int health)
    {
        Position = position;
        Health = health;
    }
}

public class Caretaker
{
    private PlayerMemento? _memento;

    public void Save(PlayerMemento memento)
    {
        _memento = memento;
    }

    public void Restore(Player player)
    {
        if (_memento != null)
        {
            player.RestoreState(_memento);
        }
    }
}

// Demonstre
class Program
{
    static void Main()
    {
        var player = new Player();
        player.Position = 5;
        player.Health = 100;

        var caretaker = new Caretaker();
        caretaker.Save(player.SaveState());

        player.Position = 10;
        caretaker.Restore(player);

        Console.WriteLine(player.Position); // Output esperado: 5
    }
}
