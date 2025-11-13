using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ConsoleApp.Topics;

public static class MainAttribute
{
    public static void Run()
    {
        Console.WriteLine("Attribute example:");

        var example = new SampleClass();
        example.Name = "TestName123456789";

        var type = typeof(SampleClass);
        // Only select SampleAttribute instances to avoid casting unrelated attributes
        var attributes = type.GetCustomAttributes(false).OfType<SampleAttribute>();

        foreach (var attr in attributes)
        {
            Console.WriteLine($"Class '{type.Name}' has attribute with description: {attr.Description}");
        }

        try
        {
            Validator.Validate(example);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Validation Error: {ex.Message}");
        }

        Console.WriteLine("==============================================");
    }
}

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
public class SampleAttribute : Attribute
{
    public string Description { get; }

    public SampleAttribute(string description)
    {
        Description = description;
    }
}

public class SampleClass
{
    [SampleAttribute("Example class attribute")]
    [MaxLengthAttribute(10)]
    [Required]
    [Display(Name = "Name Property")]
    public string? Name { get; set; }
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MaxLengthAttribute : Attribute
{
    public int Length { get; }

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }

    public bool IsValid(string? value)
    {
        if (value == null) return true; // Null is allowed
        return value.Length <= Length;
    }
}

public static class Validator
{
    public static void Validate(object obj)
    {
        Type type = obj.GetType();

        foreach (PropertyInfo prop in type.GetProperties())
        {
            foreach (var attr in prop.GetCustomAttributes(typeof(MaxLengthAttribute), false))
            {
                var maxLengthAttr = (MaxLengthAttribute)attr;
                var value = prop.GetValue(obj) as string;

                if (!maxLengthAttr.IsValid(value))
                {
                    throw new Exception($"{prop.Name} exceeds maximum length of {maxLengthAttr.Length}.");
                }
            }
        }
    }
}
