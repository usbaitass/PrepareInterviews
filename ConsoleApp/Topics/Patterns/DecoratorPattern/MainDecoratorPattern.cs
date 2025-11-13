namespace ConsoleApp.Topics.Patterns.DecoratorPattern;

public static class MainDecoratorPattern
{
    public static void Run()
    {
        Console.WriteLine("Decorator Pattern example:");

        IOrderService service = new OrderService();
        service = new LoggingOrderService(service);

        service.PlaceOrder("Laptop", 2);
        
        Console.WriteLine("==============================================");
    }
}

public interface IOrderService
{
    void PlaceOrder(string product, int quantity);
}

public class OrderService : IOrderService
{
    public void PlaceOrder(string product, int quantity)
    {
        Console.WriteLine($"Placing order: {quantity} x {product}");
    }
}

// now we want to extend functionality to add logs 
// when placing the order without modifying the original code base
public abstract class OrderServiceDecorator : IOrderService
{
    protected readonly IOrderService _innerService;

    protected OrderServiceDecorator(IOrderService innerService)
    {
        _innerService = innerService;
    }

    public abstract void PlaceOrder(string product, int quantity);
}

public class LoggingOrderService : OrderServiceDecorator
{
    public LoggingOrderService(IOrderService innerService) : base(innerService) { }

    public override void PlaceOrder(string product, int quantity)
    {
        Console.WriteLine($"[LOG] Starting order for {product}");

        _innerService.PlaceOrder(product, quantity);

        Console.WriteLine($"[LOG] Finished order for {product}");
    }
}
