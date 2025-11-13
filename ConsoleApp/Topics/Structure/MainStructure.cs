using ConsoleApp.Topics.Structure;

namespace ConsoleApp.Topics;

public static class MainStructure
{
    public static void run()
    {
        Console.WriteLine("Structures example:");

        MyStruct myStruct = new MyStruct();
        myStruct.id = 1;
        myStruct.name = "Cool";

        Console.WriteLine($"Default struct values: id = {myStruct.id}, name = {myStruct.name}");

        PointStruct ps1 = new PointStruct { X = 10 };
        PointStruct ps2 = ps1;
        ps2.X = 20;
        Console.WriteLine(ps1.X); // Output: 10 (copy by value)

        PointClass pc1 = new PointClass { X = 10 };
        PointClass pc2 = pc1;
        pc2.X = 20;
        Console.WriteLine(pc1.X); // Output: 20 (reference)

        Console.WriteLine("==============================================");
    }
}
