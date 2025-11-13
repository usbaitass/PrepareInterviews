namespace ConsoleApp.Topics;

public static class MainDelegate
{
    public delegate void Print(int value);

    public static void run()
    {
        Console.WriteLine("Delegate example:");

        // Singlecast delegate
        Print printDelegate = PrintNumber;
        printDelegate(42);

        printDelegate = PrintMoney;
        printDelegate(1000);

        // Multicast delegate
        Print printNumberDel = PrintNumber;
        Print printMoneyDel = PrintMoney;
        Print multiPrintDelegate = printNumberDel + printMoneyDel;
        multiPrintDelegate(500);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        multiPrintDelegate = multiPrintDelegate - printMoneyDel;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        multiPrintDelegate(300);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        Console.WriteLine("==============================================");
    }

    public static void PrintNumber(int number)
    {
        Console.WriteLine("Number: {0}", number);
    }

    public static void PrintMoney(int money)
    {
        Console.WriteLine("Money: {0}$", money);
    }
}
