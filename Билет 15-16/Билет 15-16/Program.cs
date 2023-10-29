//Напишите программу, реализующую декларативную атрибутивную валидацию с использованием рефлексии.
using System;
using System.Linq;
using System.Reflection;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
sealed class RangeAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public RangeAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
sealed class RequiredAttribute : Attribute
{
}

class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}

class Validator
{
    public static void Validate(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
            {
                object value = property.GetValue(obj);

                if (value == null)
                {
                    throw new ValidationException($"{property.Name} is required.");
                }
            }

            if (property.GetCustomAttributes(typeof(RangeAttribute), true).FirstOrDefault() is RangeAttribute rangeAttribute)
            {
                int value = (int)property.GetValue(obj);
                if (value < rangeAttribute.Min || value > rangeAttribute.Max)
                {
                    throw new ValidationException($"{property.Name} is out of range ({rangeAttribute.Min}-{rangeAttribute.Max}).");
                }
            }
        }
    }
}

class Person
{
    [Required]
    public string Name { get; set; }

    [Range(0, 120)]
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        try
        {
            var person = new Person { Name = "John", Age = 30 };
            Validator.Validate(person);
            Console.WriteLine("Validation passed.");
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }
    }
}
