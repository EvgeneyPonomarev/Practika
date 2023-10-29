//Напишите программу, содержащий собственный generic-тип и пример его использования
using System;

// Generic-класс с типом T
public class MyGenericClass<T>
{
    private T value;

    public MyGenericClass(T value)
    {
        this.value = value;
    }

    public T GetValue()
    {
        return value;
    }
}

public class Program
{
    public static void Main()
    {
        // Создаем экземпляр MyGenericClass с типом int
        MyGenericClass<int> intGenericClass = new MyGenericClass<int>(10);
        int intValue = intGenericClass.GetValue(); // получаем значение типа int
        Console.WriteLine("Значение типа int: " + intValue);

        // Создаем экземпляр MyGenericClass с типом string
        MyGenericClass<string> stringGenericClass = new MyGenericClass<string>("Hello, World!");
        string stringValue = stringGenericClass.GetValue(); // получаем значение типа string
        Console.WriteLine("Значение типа string: " + stringValue);
    }
}