namespace StructuralPatterns.Composite;

// Defina uma interface IMenuComponent com métodos como Display() e Add().
public interface IMenuComponent
{
    void Display(int indent = 0);
    void Add(IMenuComponent component);
}

// Implemente a classe MenuItem que representa itens individuais do menu.
public class MenuItem : IMenuComponent
{
    private readonly string _name;
    private readonly decimal _price;

    public MenuItem(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}- {_name}: ${_price:F2}");
    }

    public void Add(IMenuComponent component)
    {
        Console.WriteLine("Cannot add to a MenuItem.");
    }
}

// Implemente a classe Menu que pode conter múltiplos IMenuComponent.
public class Menu : IMenuComponent
{
    private readonly string _name;
    private readonly List<IMenuComponent> _items = new();

    public Menu(string name)
    {
        _name = name;
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}[{_name}]");
        foreach (var item in _items)
        {
            item.Display(indent + 2);
        }
    }

    public void Add(IMenuComponent component)
    {
        _items.Add(component);
    }
}

// Demonstre como montar um menu completo com itens e submenus e exibi-lo.
class Program
{
    static void Main()
    {
        var burger = new MenuItem("Burger", 15.00m);
        var fries = new MenuItem("Fries", 7.50m);
        var coke = new MenuItem("Coke", 5.00m);
        var dessert = new MenuItem("Chocolate Cake", 9.00m);

        var lunchMenu = new Menu("Lunch Menu");
        lunchMenu.Add(burger);
        lunchMenu.Add(fries);
        lunchMenu.Add(coke);

        var mainMenu = new Menu("Main Menu");
        mainMenu.Add(lunchMenu);
        mainMenu.Add(dessert);

        mainMenu.Display();
    }
}
