//Напишите программу, содержащую пример применения итератора yield .
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию чисел
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        // Вызываем метод, использующий итератор yield
        foreach (int number in GetEvenNumbers(numbers))
        {
            Console.WriteLine(number);
        }
    }

    // Метод, возвращающий только четные числа из коллекции
    static IEnumerable<int> GetEvenNumbers(List<int> numbers)
    {
        foreach (int number in numbers)
        {
            // Используем yield return для возврата только четных чисел
            if (number % 2 == 0)
            {
                yield return number;
            }
        }
    }
}
