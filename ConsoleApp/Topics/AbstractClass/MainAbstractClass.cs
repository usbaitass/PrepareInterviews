using ConsoleApp.Topics.AbstractClass;

namespace ConsoleApp.Topics;

public static class MainAbstractClass
{
    public static void Run()
    {
        Console.WriteLine("Abstract Class example:");

        Person person = new Student("Alice");
        person.Greet();
        person.Introduce();

        Student? student = person as Student;
        if (student != null)
        {
            student.Age = 20;
            student.Speak();
        }

        Console.WriteLine("==============================================");
    }
}
