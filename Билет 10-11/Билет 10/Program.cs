//Напишите программу, реализующую шаблон проектирования cтратегия
 using System;

// Интерфейс стратегии
public interface ITaxStrategy
{
    double CalculateTax(double income);
}

// Конкретные стратегии
public class IndividualTaxStrategy : ITaxStrategy
{
    public double CalculateTax(double income)
    {
        return income * 0.15; // Простая стратегия для физических лиц
    }
}

public class CorporateTaxStrategy : ITaxStrategy
{
    public double CalculateTax(double income)
    {
        return income * 0.25; // Простая стратегия для юридических лиц
    }
}

// Контекст
public class TaxCalculator
{
    private ITaxStrategy _strategy;

    public TaxCalculator(ITaxStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ITaxStrategy strategy)
    {
        _strategy = strategy;
    }

    public double CalculateTax(double income)
    {
        return _strategy.CalculateTax(income);
    }
}

class Program
{
    static void Main()
    {
        var individual = new IndividualTaxStrategy();
        var corporate = new CorporateTaxStrategy();

        var calculator = new TaxCalculator(individual);
        double individualTax = calculator.CalculateTax(100000);

        calculator.SetStrategy(corporate);
        double corporateTax = calculator.CalculateTax(1000000);

        Console.WriteLine($"Individual tax: {individualTax}");
        Console.WriteLine($"Corporate tax: {corporateTax}");
    }
}


/* Запасой вариант 
using System;

// Интерфейс для всех стратегий
interface IStrategy
{
    void Execute();
}

// Конкретные стратегии
class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Выполнение стратегии A");
    }
}

class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Выполнение стратегии B");
    }
}

class ConcreteStrategyC : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Выполнение стратегии C");
    }
}

// Контекст, использующий стратегию
class Context
{
    private IStrategy strategy;

    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем объект контекста
        Context context = new Context(new ConcreteStrategyA());

        // Выполняем стратегию A
        context.ExecuteStrategy();

        // Изменяем стратегию на B и выполняем её
        context.SetStrategy(new ConcreteStrategyB());
        context.ExecuteStrategy();

        // Изменяем стратегию на C и выполняем её
        context.SetStrategy(new ConcreteStrategyC());
        context.ExecuteStrategy();

        Console.ReadKey();
    }
}

 */
