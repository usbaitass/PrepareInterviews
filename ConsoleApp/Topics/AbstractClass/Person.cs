namespace ConsoleApp.Topics.AbstractClass;

public abstract class Person : Human
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }


    public abstract void Introduce();

    // in virtual method, there must be implementation
    public virtual void Greet()
    {
        Console.WriteLine($"Hello, my name is {Name}.");
    }
}

public abstract class Human
{
    public int Age { get; set; }
    public abstract void Speak();
}

public class Student : Person
{
    public Student(string name) : base(name)
    {
    }

    public override void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name}, a student.");
    }

    public override void Greet()
    {
        Console.WriteLine($"Hey there! I'm {Name}, nice to meet you!");
    }

    public override void Speak()
    {
        Console.WriteLine("Student is speaking. My age is {0}.", this.Age);
    }
}
