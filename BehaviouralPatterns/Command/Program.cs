namespace Command;

// Crie uma interface ICommand com os métodos Execute() e Undo().
public interface ICommand
{
    void Execute();
    void Undo();
}

// Implemente comandos como WriteTextCommand e DeleteTextCommand.
public class TextEditor
{
    private string _content = "";

    public void Write(string text)
    {
        _content += text;
    }

    public void Delete(int length)
    {
        if (length > _content.Length)
            length = _content.Length;

        _content = _content.Substring(0, _content.Length - length);
    }

    public string GetContent()
    {
        return _content;
    }
}

public class WriteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;

    public WriteTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _editor.Write(_text);
    }

    public void Undo()
    {
        _editor.Delete(_text.Length);
    }
}

public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private string _deletedText = "";
    private readonly int _length;

    public DeleteTextCommand(TextEditor editor, int length)
    {
        _editor = editor;
        _length = length;
    }

    public void Execute()
    {
        var content = _editor.GetContent();
        if (_length > content.Length)
            _deletedText = content;
        else
            _deletedText = content.Substring(content.Length - _length, _length);

        _editor.Delete(_length);
    }

    public void Undo()
    {
        _editor.Write(_deletedText);
    }
}

// Use uma pilha para implementar o histórico de comandos.
public class CommandManager
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
        }
    }
}

// Demonstração 
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var commandManager = new CommandManager();

        commandManager.ExecuteCommand(new WriteTextCommand(editor, "Hello, "));
        commandManager.ExecuteCommand(new WriteTextCommand(editor, "world!"));

        commandManager.Undo();
        commandManager.Undo();
        commandManager.Redo();

        Console.WriteLine(editor.GetContent());
    }
}
