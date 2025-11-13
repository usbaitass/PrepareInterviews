namespace ConsoleApp.Topics;

public static class MainOrder
{
    public static void run()
    {
        Console.WriteLine("MainTemplate example:");



        Console.WriteLine("==============================================");
    }
}

class OrderService
{
    private readonly IProcessingService _processingService;

    public OrderService(IProcessingService processingService)
    {
        _processingService = processingService;
    }

    public void SubmitOrder(Order order)
    {
        _processingService.Process(order);
    }
}

class Order
{
    public int id { get; set; }
    public string? type { get; set; }
    public string? details { get; set; }
}

class ProcessingService : IProcessingService
{
    public void Process(Order order)
    {
        // do something
    }
}

interface IProcessingService
{
    void Process(Order order);
}
