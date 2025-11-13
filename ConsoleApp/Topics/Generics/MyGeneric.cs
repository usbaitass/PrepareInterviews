namespace ConsoleApp.Topics.Generics;

public class MyGeneric<T>
{
    private T? data;

    public T? value
    {
        get { return data; }
        set { data = value; }
    }
}
