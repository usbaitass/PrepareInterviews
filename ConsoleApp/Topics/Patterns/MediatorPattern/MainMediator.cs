namespace ConsoleApp.Topics;

public static class MainMediator
{
    public static void run()
    {
        Console.WriteLine("Mediator Pattern example:");

        ITrafficMediator tower = new TrafficTower();

        var car1 = new Car(tower, "Car A");
        var bus1 = new Bus(tower, "Bus B");

        tower.RegisterVehicle(car1);
        tower.RegisterVehicle(bus1);

        car1.EnterIntersection();
        bus1.EnterIntersection(); // must wait

        car1.ExitIntersection();
        bus1.EnterIntersection(); // now allowed
        bus1.ExitIntersection();

        /*
        Why It’s a Mediator Pattern
        TrafficTower acts as the mediator that manages who can enter or exit.
        Car and Bus do not talk to each other directly.
        Adding more vehicle types (like Ambulance) only requires 
        updating the mediator logic — no coupling between vehicles.
        */

        Console.WriteLine("==============================================");
    }
}

class Bus : Vehicle
{
    public Bus(ITrafficMediator mediator, string name) : base(mediator, name) { }

    public override void EnterIntersection()
    {
        Console.WriteLine($"{Name} (Bus) requests entry.");
        if (mediator.RequestEntry(this))
            Console.WriteLine($"{Name} is passing through slowly...");
    }

    public override void ExitIntersection()
    {
        mediator.NotifyExit(this);
    }
}

class Car : Vehicle
{
    public Car(ITrafficMediator mediator, string name) : base(mediator, name) { }

    public override void EnterIntersection()
    {
        Console.WriteLine($"{Name} (Car) requests entry.");
        if (mediator.RequestEntry(this))
            Console.WriteLine($"{Name} is passing through...");
    }

    public override void ExitIntersection()
    {
        mediator.NotifyExit(this);
    }
}

abstract class Vehicle
{
    protected ITrafficMediator mediator;
    public string Name { get; }

    protected Vehicle(ITrafficMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
    }

    public abstract void EnterIntersection();
    public abstract void ExitIntersection();
}

class TrafficTower : ITrafficMediator
{
    private readonly List<Vehicle> _vehiclesInIntersection = new();

    public void RegisterVehicle(Vehicle vehicle)
    {
        Console.WriteLine($"{vehicle.Name} registered with Traffic Tower.");
    }

    public bool RequestEntry(Vehicle vehicle)
    {
        if (_vehiclesInIntersection.Count == 0)
        {
            _vehiclesInIntersection.Add(vehicle);
            Console.WriteLine($"{vehicle.Name} entered the intersection.");
            return true;
        }

        Console.WriteLine($"{vehicle.Name} must wait. Intersection occupied by {_vehiclesInIntersection[0].Name}.");
        return false;
    }

    public void NotifyExit(Vehicle vehicle)
    {
        _vehiclesInIntersection.Remove(vehicle);
        Console.WriteLine($"{vehicle.Name} exited the intersection.");
    }
}

interface ITrafficMediator
{
    void RegisterVehicle(Vehicle vehicle);
    bool RequestEntry(Vehicle vehicle);
    void NotifyExit(Vehicle vehicle);
}
