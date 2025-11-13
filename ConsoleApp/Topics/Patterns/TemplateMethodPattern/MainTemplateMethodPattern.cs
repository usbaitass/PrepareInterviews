namespace ConsoleApp.Topics.Patterns;

public static class MainTemplateMethodPattern
{
    public static void Run()
    {
        Console.WriteLine("Template Method Pattern example:");

        DataExporter csvExporter = new CsvDataExporter();
        csvExporter.Export();

        Console.WriteLine("==============================================");
    }
}

// Abstract class defines the template
abstract class DataExporter
{
    // Template method - defines the algorithm skeleton
    public void Export()
    {
        ReadData();
        ProcessData();
        WriteData();
    }

    // Common step
    protected void ReadData()
    {
        Console.WriteLine("Reading data from database...");
    }

    // Steps that can vary
    protected abstract void ProcessData();
    protected abstract void WriteData();
}

// Concrete class 1
class CsvDataExporter : DataExporter
{
    protected override void ProcessData()
    {
        Console.WriteLine("Processing data for CSV format...");
    }

    protected override void WriteData()
    {
        Console.WriteLine("Writing data to CSV file...");
    }
}
