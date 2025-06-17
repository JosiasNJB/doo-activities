namespace Template;

// Crie uma classe base ReportGenerator com o método GenerateReport().
public abstract class ReportGenerator
{
    public void GenerateReport()
    {
        GenerateHeader();
        ExportReport();
    }

    private void GenerateHeader()
    {
        System.Console.WriteLine("Generating report header...");
    }

    protected abstract void ExportReport();
}

// Substitua métodos específicos em subclasses como PdfReportGenerator e ExcelReportGenerator.
public class PdfReportGenerator : ReportGenerator
{
    protected override void ExportReport()
    {
        System.Console.WriteLine("Exporting to PDF...");
    }
}

public class ExcelReportGenerator : ReportGenerator
{
    protected override void ExportReport()
    {
        System.Console.WriteLine("Exporting to Excel...");
    }
}

class Program
{
    static void Main()
    {
        var pdfReport = new PdfReportGenerator();
        pdfReport.GenerateReport();

        var excelReport = new ExcelReportGenerator();
        excelReport.GenerateReport();
    }
}
