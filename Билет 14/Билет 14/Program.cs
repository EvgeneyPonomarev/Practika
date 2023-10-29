//Напишите программу, реализующую шаблон проектирования builder
using System;

public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }

    // Дополнительные параметры компьютера
    // ...
}

// Интерфейс строителя
public interface IComputerBuilder
{
    void SetCPU();
    void SetRAM();
    void SetStorage();
    Computer GetComputer();
}

// Конкретный строитель
public class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void SetCPU()
    {
        computer.CPU = "High-end gaming CPU";
    }

    public void SetRAM()
    {
        computer.RAM = "32GB RAM";
    }

    public void SetStorage()
    {
        computer.Storage = "1TB SSD";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

// Руководитель строительства (директор)
public class Director
{
    private IComputerBuilder builder;

    public Director(IComputerBuilder builder)
    {
        this.builder = builder;
    }

    public void ConstructComputer()
    {
        builder.SetCPU();
        builder.SetRAM();
        builder.SetStorage();
    }

    public Computer GetComputer()
    {
        return builder.GetComputer();
    }
}

class Program
{
    static void Main()
    {
        IComputerBuilder builder = new GamingComputerBuilder();
        Director director = new Director(builder);

        director.ConstructComputer();
        Computer computer = director.GetComputer();

        Console.WriteLine("CPU: " + computer.CPU);
        Console.WriteLine("RAM: " + computer.RAM);
        Console.WriteLine("Storage: " + computer.Storage);
    }
}


/* Запасной вариант
 using System;

// Пример класса продукта, который мы строим
class Pizza
{
    public string Size { get; set; }
    public bool Cheese { get; set; }
    public bool Pepperoni { get; set; }
    public bool Bacon { get; set; }

    public void Display()
    {
        Console.WriteLine($"Size: {Size}");
        Console.WriteLine($"Cheese: {(Cheese ? "Yes" : "No")}");
        Console.WriteLine($"Pepperoni: {(Pepperoni ? "Yes" : "No")}");
        Console.WriteLine($"Bacon: {(Bacon ? "Yes" : "No")}");
    }
}

// Интерфейс строителя, определяющий шаги построения продукта
interface IPizzaBuilder
{
    void SetSize(string size);
    void AddCheese();
    void AddPepperoni();
    void AddBacon();
    Pizza GetPizza();
}

// Конкретный строитель для создания пиццы
class PizzaBuilder : IPizzaBuilder
{
    private Pizza pizza;

    public PizzaBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        pizza = new Pizza();
    }

    public void SetSize(string size)
    {
        pizza.Size = size;
    }

    public void AddCheese()
    {
        pizza.Cheese = true;
    }

    public void AddPepperoni()
    {
        pizza.Pepperoni = true;
    }

    public void AddBacon()
    {
        pizza.Bacon = true;
    }

    public Pizza GetPizza()
    {
        Pizza result = pizza;
        Reset();
        return result;
    }
}

// Директор, который управляет процессом построения продукта
class Waiter
{
    private IPizzaBuilder pizzaBuilder;

    public void SetPizzaBuilder(IPizzaBuilder builder)
    {
        pizzaBuilder = builder;
    }

    public Pizza GetPizza()
    {
        return pizzaBuilder.GetPizza();
    }

    public void ConstructPizza()
    {
        pizzaBuilder.SetSize("Medium"); // Настройка размера
        pizzaBuilder.AddCheese(); // Добавление сыра
        pizzaBuilder.AddPepperoni(); // Добавление пепперони
        pizzaBuilder.AddBacon(); // Добавление бекона
    }
}

// Тестовый класс для демонстрации использования шаблона Builder
class Program
{
    static void Main(string[] args)
    {
        Waiter waiter = new Waiter();
        PizzaBuilder pizzaBuilder = new PizzaBuilder();
        waiter.SetPizzaBuilder(pizzaBuilder);

        waiter.ConstructPizza();
        Pizza pizza = waiter.GetPizza();
        pizza.Display();
    }
}

 */