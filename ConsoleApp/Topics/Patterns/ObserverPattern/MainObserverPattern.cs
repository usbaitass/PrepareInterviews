namespace ConsoleApp.Topics.Patterns;

public static class MainObserverPattern
{
    public static void Run()
    {
        Console.WriteLine("Observer Pattern example:");

        var agency = new NewsAgency();
        var cnn = new NewsChannel("CNN");
        var bbc = new NewsChannel("BBC");

        using var cnnSubscription = agency.Subscribe(cnn);
        using var bbcSubscription = agency.Subscribe(bbc);

        agency.PublishNews(".NET 9 Released!");
        agency.PublishNews("AI Advances in 2025!");

        Console.WriteLine("==============================================");
    }
}

public class NewsAgency : IObservable<string>
{
    private List<IObserver<string>> _observers = new();

    public IDisposable Subscribe(IObserver<string> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    public void PublishNews(string news)
    {
        foreach (var observer in _observers)
            observer.OnNext(news);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<string>> _observers;
        private IObserver<string> _observer;

        public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null)
                _observers.Remove(_observer);
        }
    }
}

public class NewsChannel : IObserver<string>
{
    private string _name;
    public NewsChannel(string name) => _name = name;

    public void OnNext(string value) => Console.WriteLine($"{_name} received news: {value}");
    public void OnError(Exception error) => Console.WriteLine($"{_name} error: {error.Message}");
    public void OnCompleted() => Console.WriteLine($"{_name} has no more news.");
}
