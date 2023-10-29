//Напишите программу, в которой определено событие и выполнена подписка на него. Продемонстрируйте смысл событий.
using System;

// Класс, представляющий термостат
class Thermostat
{
    public event EventHandler<EventArgs> TemperatureReached; // Определение события

    private int currentTemperature;

    public int CurrentTemperature
    {
        get { return currentTemperature; }
        set
        {
            currentTemperature = value;
            if (currentTemperature >= 100) // Если температура достигла 100 градусов
            {
                OnTemperatureReached(); // Генерируем событие
            }
        }
    }

    protected virtual void OnTemperatureReached()
    {
        TemperatureReached?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main()
    {
        Thermostat thermostat = new Thermostat();

        // Подписка на событие
        thermostat.TemperatureReached += Thermostat_TemperatureReached;

        Console.WriteLine("Подождите, пока температура достигнет 100 градусов.");
        while (thermostat.CurrentTemperature < 100)
        {
            // Симуляция изменения температуры
            thermostat.CurrentTemperature += 10;
            Console.WriteLine($"Текущая температура: {thermostat.CurrentTemperature} градусов");
        }

        Console.WriteLine("Температура достигла 100 градусов. Событие произошло!");
    }

    // Метод-обработчик события
    private static void Thermostat_TemperatureReached(object sender, EventArgs e)
    {
        Console.WriteLine("Событие: Температура достигла 100 градусов!");
    }
}