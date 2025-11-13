namespace ConsoleApp.Topics.Patterns;

public static class MainFactoryPattern
{
    public static void Run()
    {
        Console.WriteLine("Factory Pattern example:");

        INotification notification = NotificationFactory.CreateNotification("email");
        notification.Notify("Factory Pattern in .NET");

        Console.WriteLine("==============================================");
    }
}

public interface INotification
{
    void Notify(string message);
}

public class EmailNotification : INotification
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SmsNotification : INotification
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public static class NotificationFactory
{
    public static INotification CreateNotification(string channel)
    {
        return channel.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms" => new SmsNotification(),
            _ => throw new ArgumentException("Invalid notification type")
        };
    }
}
