namespace ChainOfResponsability;

// Crie classes InvoiceHandler, ReceiptHandler e BillHandler que herdam de uma classe base DocumentHandler.
public abstract class DocumentHandler
{
    protected DocumentHandler? _next;

    public DocumentHandler SetNext(DocumentHandler next)
    {
        _next = next;
        return next;
    }

    public void Handle(string documentType)
    {
        if (!Process(documentType))
        {
            if (_next != null)
            {
                _next.Handle(documentType);
            }
            else
            {
                Console.WriteLine($"Cannot process {documentType}.");
            }
        }
    }

    protected abstract bool Process(string documentType);
}

public class InvoiceHandler : DocumentHandler
{
    protected override bool Process(string documentType)
    {
        if (documentType == "Invoice")
        {
            Console.WriteLine("Processing Invoice...");
            return true;
        }
        return false;
    }
}

public class ReceiptHandler : DocumentHandler
{
    protected override bool Process(string documentType)
    {
        if (documentType == "Receipt")
        {
            Console.WriteLine("Processing Receipt...");
            return true;
        }
        return false;
    }
}

public class BillHandler : DocumentHandler
{
    protected override bool Process(string documentType)
    {
        if (documentType == "Bill")
        {
            Console.WriteLine("Processing Bill...");
            return true;
        }
        return false;
    }
}

// Use o padrão para processar diferentes tipos de documentos.
class Program
{
    static void Main()
    {
        var handler = new InvoiceHandler();
        handler.SetNext(new ReceiptHandler()).SetNext(new BillHandler());

        handler.Handle("Invoice");
        handler.Handle("Unknown");
    }
}
