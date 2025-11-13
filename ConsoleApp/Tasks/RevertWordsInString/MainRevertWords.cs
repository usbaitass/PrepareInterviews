using System.Text;

namespace ConsoleApp.Tasks;

public static class MainRevertWords
{

    public static void run()
    {
        Console.WriteLine("MainRevertWords example:");

        string input = "Hello World from Prepare Interviews";
        string result = RevertWords(input);
        Console.WriteLine($"Input: {input}");
        Console.WriteLine($"Reverted: {result}");

        Console.WriteLine("==============================================");
    }

    public static string RevertWords(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var words = input.Split(' ');

        var stringBuilder = new StringBuilder();

        foreach (var item in words)
        {
            var x = new string(item.Reverse().ToArray());
            stringBuilder.Append(x);
            stringBuilder.Append(" ");
        }

        return stringBuilder.ToString();
    }
}
