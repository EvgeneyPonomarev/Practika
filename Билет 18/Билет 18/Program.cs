//Напишите программу, использующие флаговые перечисления
using System;

[Flags]
enum DaysOfWeek
{
    None = 0,
    Sunday = 1,
    Monday = 2,
    Tuesday = 4,
    Wednesday = 8,
    Thursday = 16,
    Friday = 32,
    Saturday = 64
}

class Program
{
    static void Main()
    {
        // Используем флаговые перечисления для представления комбинации дней недели.
        DaysOfWeek workDays = DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday;

        Console.WriteLine("Рабочие дни недели: " + workDays);

        // Проверяем, включен ли конкретный день недели в комбинацию.
        bool isThursdayWorkDay = (workDays & DaysOfWeek.Thursday) == DaysOfWeek.Thursday;

        Console.WriteLine("Четверг - рабочий день: " + isThursdayWorkDay);

        // Добавляем субботу в комбинацию.
        workDays |= DaysOfWeek.Saturday;

        Console.WriteLine("Добавили субботу: " + workDays);

        // Убираем понедельник из комбинации.
        workDays &= ~DaysOfWeek.Monday;

        Console.WriteLine("Убрали понедельник: " + workDays);
    }
}