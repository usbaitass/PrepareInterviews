namespace ConsoleApp.Topics;

public static class MainString
{
    public static void run()
    {
        Console.WriteLine("string example:");

        string a = "hello ";
        string b = "world!";

        // allocates new string, total of 3 strings in memory
        string c = a + b;

        Console.WriteLine(c);
        Console.WriteLine("==============================================");
    }
}
