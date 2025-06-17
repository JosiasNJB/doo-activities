namespace Proxy;

// Defina uma interface IImage com o método Display().
public interface IImage
{
    void Display();
}

// Implemente a classe RealImage que carrega e exibe a imagem real.
public class RealImage : IImage
{
    private readonly string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Loading image from disk: {_fileName}");
    }

    public void Display()
    {
        Console.WriteLine($"Displaying image: {_fileName}");
    }
}

// Crie a classe ProxyImage que controla o acesso a RealImage.
public class ProxyImage : IImage
{
    private readonly string _fileName;
    private RealImage? _realImage;

    public ProxyImage(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        if (_realImage == null)
        {
            _realImage = new RealImage(_fileName);
        }

        _realImage.Display();
    }
}

// Demonstre como usar ProxyImage para atrasar o carregamento da imagem até que Display() seja chamado.
class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("high_res_photo.jpg");

        Console.WriteLine("Image created, but not loaded.");

        image.Display();

        image.Display();
    }
}
