namespace Visitor;

// Crie uma interface IVisitor com métodos Visit(ElementA) e Visit(ElementB).
public interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
}

// Crie classes de elementos que aceitam visitantes.
public interface IElement
{
    void Accept(IVisitor visitor);
}

public class ElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ValidationVisitor : IVisitor
{
    public void Visit(ElementA element)
    {
        System.Console.WriteLine("Validating ElementA...");
    }

    public void Visit(ElementB element)
    {
        System.Console.WriteLine("Validating ElementB...");
    }
}

class Program
{
    static void Main()
    {
        var visitor = new ValidationVisitor();
        var elementA = new ElementA();
        elementA.Accept(visitor);
    }
}
