using System.Collections;

namespace Iterator;

// Crie uma classe Playlist que implemente o método GetEnumerator().
public class Playlist : IEnumerable<string>
{
    private readonly List<string> _songs = new();
    private bool _shuffle = false;
    private readonly Random _random = new();

    public void Add(string song)
    {
        _songs.Add(song);
    }

    // Adicione uma funcionalidade para alternar entre iteração ordenada e aleatória.
    public void SetShuffle(bool shuffle)
    {
        _shuffle = shuffle;
    }

    public IEnumerator<string> GetEnumerator()
    {
        if (!_shuffle)
        {
            foreach (var song in _songs)
                yield return song;
        }
        else
        {
            var shuffled = new List<string>(_songs);
            int n = shuffled.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                (shuffled[k], shuffled[n]) = (shuffled[n], shuffled[k]);
            }

            foreach (var song in shuffled)
                yield return song;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Demonstre
class Program
{
    static void Main()
    {
        var playlist = new Playlist();
        playlist.Add("Song 1");
        playlist.Add("Song 2");
        playlist.Add("Song 3");

        playlist.SetShuffle(false);

        foreach (var song in playlist)
        {
            Console.WriteLine(song);
        }
    }
}
