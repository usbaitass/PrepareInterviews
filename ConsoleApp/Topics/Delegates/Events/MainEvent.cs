namespace ConsoleApp.Topics;

public static class MainEvent
{
    public static void run()
    {
        Console.WriteLine("Event example:");

        Alarm alarm = new Alarm();
        AlarmSubscriber subscriber = new AlarmSubscriber("Sub-1");
        subscriber.Subscribe(alarm);

        AlarmSubscriber subscriber2 = new AlarmSubscriber("Sub-2");
        subscriber2.Subscribe(alarm);

        alarm.TriggerAlarm();  // Output: Alarm triggered! + Alarm received!

        Console.WriteLine("==============================================");
    }
}

class Alarm
{
    // 1. Define the delegate type
    public delegate void AlarmEventHandler(object sender, EventArgs e);

    // 2. Declare the event
    public event AlarmEventHandler? OnAlarm;

    // 3. Method to raise the event
    public void TriggerAlarm()
    {
        Console.WriteLine("Alarm triggered!");
        OnAlarm?.Invoke(this, EventArgs.Empty);  // Raise event safely
    }
}

class AlarmSubscriber
{
    private string _name { get; set; }

    public AlarmSubscriber(string name)
    {
        _name = name;
    }

    public void Subscribe(Alarm alarm)
    {
        alarm.OnAlarm += AlarmHandler;  // Subscribe to the event
    }

    private void AlarmHandler(object sender, EventArgs e)
    {
        Console.WriteLine("{0}: Alarm received! Taking action...", _name);
    }
}
