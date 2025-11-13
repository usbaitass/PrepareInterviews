namespace ConsoleApp.Topics.Structure;

public class MyClass : ParentClass
{
    public int id { get; set; }
    public string? name { get; set; }
}

public class ParentClass
{
    public int parentId { get; set; }
}
