using ConsoleApp.Topics.Generics;

namespace ConsoleApp.Topics;

public static class MainGenerics
{
    public static void run()
    {
        Console.WriteLine("Generics example:");

        MyGeneric<string> genericString = new MyGeneric<string>();
        genericString.value = "Hello, Generics!";
        Console.WriteLine(genericString.value);


        MyGeneric<int> genericInt = new MyGeneric<int>();
        genericInt.value = 42;
        Console.WriteLine(genericInt.value);

        Console.WriteLine("==============================================");
    }
}
