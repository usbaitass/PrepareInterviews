namespace ConsoleApp.Topics.Structure;

public struct MyStruct //: ParentStruct
{
    public int id { get; set; }
    public string name { get; set; }
}

public struct ParentStruct
{
    public int parentId { get; set; }
}

struct PointStruct
{
    public int X;
}

class PointClass
{
    public int X;
}
