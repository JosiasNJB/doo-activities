namespace Bridge;

// Defina uma interface IColor com um método ApplyColor().
public interface IColor
{
    void ApplyColor();
}

// Implemente as cores concretas (RedColor, BlueColor) que implementam IColor.
public class RedColor : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Color: Red");
    }
}

public class BlueColor : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Color: Blue");
    }
}

// Crie uma classe abstrata Shape que tem um objeto IColor.
public abstract class Shape
{
    protected IColor color;

    public Shape(IColor color)
    {
        this.color = color;
    }

    public abstract void Draw();
}

// Implemente formas concretas (Circle, Square) que derivam de Shape.
public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.Write("Drawing a Circle - ");
        color.ApplyColor();
    }
}

public class Square : Shape
{
    public Square(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.Write("Drawing a Square - ");
        color.ApplyColor();
    }
}

// Demonstre como você pode criar diferentes combinações de formas e cores.
class Program
{
    static void Main()
    {
        Shape redCircle = new Circle(new RedColor());
        Shape blueSquare = new Square(new BlueColor());
        Shape blueCircle = new Circle(new BlueColor());
        Shape redSquare = new Square(new RedColor());

        redCircle.Draw();
        blueSquare.Draw();
        blueCircle.Draw();
        redSquare.Draw();
    }
}

