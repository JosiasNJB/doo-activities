namespace Facade;

// Implemente classes para cada subsistema (DvdPlayer, Projector, Lights, SoundSystem).
public class DvdPlayer
{
    public void On() => Console.WriteLine("DVD Player: On");
    public void Play(string movie) => Console.WriteLine($"DVD Player: Playing \"{movie}\"");
    public void Off() => Console.WriteLine("DVD Player: Off");
}

public class Projector
{
    public void On() => Console.WriteLine("Projector: On");
    public void SetInput(string input) => Console.WriteLine($"Projector: Input set to {input}");
    public void Off() => Console.WriteLine("Projector: Off");
}

public class Lights
{
    public void Dim() => Console.WriteLine("Lights: Dimming lights");
    public void On() => Console.WriteLine("Lights: Turning lights on");
}

public class SoundSystem
{
    public void On() => Console.WriteLine("Sound System: On");
    public void SetVolume(int level) => Console.WriteLine($"Sound System: Volume set to {level}");
    public void Off() => Console.WriteLine("Sound System: Off");
}

// Crie a classe HomeTheaterFacade com os métodos PlayMovie(string movie) e EndMovie().
public class HomeTheaterFacade
{
    private readonly DvdPlayer _dvd;
    private readonly Projector _projector;
    private readonly Lights _lights;
    private readonly SoundSystem _sound;

    public HomeTheaterFacade(DvdPlayer dvd, Projector projector, Lights lights, SoundSystem sound)
    {
        _dvd = dvd;
        _projector = projector;
        _lights = lights;
        _sound = sound;
    }

    public void PlayMovie(string movie)
    {
        Console.WriteLine("\nStarting movie...");
        _lights.Dim();
        _projector.On();
        _projector.SetInput("DVD");
        _sound.On();
        _sound.SetVolume(20);
        _dvd.On();
        _dvd.Play(movie);
    }

    public void EndMovie()
    {
        Console.WriteLine("\nEnding movie...");
        _dvd.Off();
        _projector.Off();
        _sound.Off();
        _lights.On();
    }
}

// Demonstre como o usuário pode usar HomeTheaterFacade para controlar todo o sistema de forma simples.
class Program
{
    static void Main()
    {
        var dvd = new DvdPlayer();
        var projector = new Projector();
        var lights = new Lights();
        var sound = new SoundSystem();

        var homeTheater = new HomeTheaterFacade(dvd, projector, lights, sound);

        homeTheater.PlayMovie("The Matrix");
        homeTheater.EndMovie();
    }
}
