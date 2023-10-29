//Напишите программу, реализующую шаблон проектирования наблюдатель
using System;
using System.Collections.Generic;

// Интерфейс для наблюдателей
public interface IObserver
{
    void Update(string message);
}

// Конкретный класс наблюдателя
public class ConcreteObserver : IObserver
{
    private string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} получил сообщение: {message}");
    }
}

// Интерфейс для субъекта
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string message);
}

// Конкретный класс субъекта
public class ConcreteSubject : ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }

    public void DoSomethingImportant()
    {
        // Что-то важное происходит в этом субъекте
        // Оповещаем наблюдателей
        NotifyObservers("Важное событие произошло!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConcreteSubject subject = new ConcreteSubject();

        // Создаем наблюдателей
        IObserver observer1 = new ConcreteObserver("Наблюдатель 1");
        IObserver observer2 = new ConcreteObserver("Наблюдатель 2");

        // Регистрируем наблюдателей
        subject.RegisterObserver(observer1);
        subject.RegisterObserver(observer2);

        // Субъект выполняет действие
        subject.DoSomethingImportant();

        // Наблюдатели автоматически получат уведомления и обновятся
    }
}
