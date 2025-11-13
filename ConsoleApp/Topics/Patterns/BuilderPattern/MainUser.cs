namespace ConsoleApp.Topics;

public static class MainUser
{
    public static void Run()
    {
        Console.WriteLine("Builder Pattern example:");

        var newUser = UserBuilderExtension.Builder()
            .WithName("John")
            .WithAge(20)
            .WithAddress("New York")
            .IsActive(true)
            .Build();

        Console.WriteLine(newUser.ToString());

        Console.WriteLine("==============================================");
    }
}

public record User
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }
}

public static class UserBuilderExtension
{
    public static UserBuilder Builder()
    {
        return new UserBuilder();
    }

    public class UserBuilder
    {
        private string? _name;
        private int _age;
        private string? _address;
        private bool _isActive;

        public UserBuilder WithName(string name) { _name = name; return this; }
        public UserBuilder WithAge(int age) { _age = age; return this; }
        public UserBuilder WithAddress(string address) { _address = address; return this; }
        public UserBuilder IsActive(bool isActive) { _isActive = isActive; return this; }

        public User Build() => new User
        {
            Name = _name,
            Age = _age,
            Address = _address,
            IsActive = _isActive
        };
    }
}
