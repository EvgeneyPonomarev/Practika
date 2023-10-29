//Напишите программу, использующую yield return.
using System;
using System.Collections.Generic;

class FibonacciSequence
{
    static IEnumerable<int> GenerateFibonacciSequence(int n)
    {
        int a = 0;
        int b = 1;

        for (int i = 0; i < n; i++)
        {
            yield return a;
            int temp = a;
            a = b;
            b = temp + b;
        }
    }

    static void Main()
    {
        int n = 10; // Количество чисел Фибоначчи, которые хотите сгенерировать

        Console.WriteLine($"Первые {n} чисел Фибоначчи:");
        foreach (int number in GenerateFibonacciSequence(n))
        {
            Console.Write(number + " ");
        }
    }
}