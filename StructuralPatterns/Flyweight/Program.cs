namespace Flyweight;

// Crie uma classe TreeType que contém o estado compartilhado (por exemplo, textura, cor).
public class TreeType
{
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing tree '{Name}' at ({x}, {y}) with color {Color} and texture {Texture}");
    }
}

// Implemente uma fábrica TreeFactory que gerencia os objetos TreeType.
public class TreeFactory
{
    private static readonly Dictionary<string, TreeType> _treeTypes = new();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}-{color}-{texture}";

        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
        }

        return _treeTypes[key];
    }
}

// Crie a classe Tree que contém o estado extrínseco (por exemplo, posição).
public class Tree
{
    private readonly int _x;
    private readonly int _y;
    private readonly TreeType _type;

    public Tree(int x, int y, TreeType type)
    {
        _x = x;
        _y = y;
        _type = type;
    }

    public void Draw()
    {
        _type.Draw(_x, _y);
    }
}

// Demonstre como criar múltiplas instâncias de Tree que compartilham o mesmo TreeType.
class Program
{
    static void Main()
    {
        var trees = new List<Tree>();

        var oakType = TreeFactory.GetTreeType("Oak", "Green", "Rough");
        trees.Add(new Tree(10, 20, oakType));
        trees.Add(new Tree(15, 25, oakType));
        trees.Add(new Tree(20, 30, oakType));

        var pineType = TreeFactory.GetTreeType("Pine", "Dark Green", "Smooth");
        trees.Add(new Tree(5, 10, pineType));
        trees.Add(new Tree(6, 12, pineType));

        foreach (var tree in trees)
        {
            tree.Draw();
        }
    }
}
