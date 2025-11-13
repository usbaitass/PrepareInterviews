namespace ConsoleApp.Topics;

public static class MainYield
{
    public static void run()
    {
        Console.WriteLine("Yield example:");

        foreach (var number in GetNumbers())
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("==============================================");
    }

    static IEnumerable<int> GetNumbers()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }

    static IEnumerable<int> CountTo(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            yield return i;
        }
    }

    static IEnumerable<int> EvenNumbers(IEnumerable<int> numbers)
    {
        foreach (var n in numbers)
        {
            if (n % 2 == 0)
                yield return n;
        }
    }

    //You don’t load the whole file into memory.
    // You can process lines on-the-fly (great for logs, CSVs, etc.)
    public static IEnumerable<string> ReadLines(string path)
    {
        using var reader = new StreamReader(path);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line; // yield each line as it's read
        }
    }


}
