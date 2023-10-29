//Напишите программу, считывающую с клавиатуры цифры и сохраняющие их в файл. Продемонстрируйте чтение из этого файла.
using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Считывание цифр с клавиатуры и сохранение в файл
        Console.WriteLine("Введите цифры, которые хотите сохранить в файл (для завершения введите 'q'):");

        using (StreamWriter writer = new StreamWriter("цифры.txt"))
        {
            string input;
            while ((input = Console.ReadLine()) != "q")
            {
                if (int.TryParse(input, out int number))
                {
                    writer.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Введено некорректное значение. Попробуйте ещё раз.");
                }
            }
        }

        Console.WriteLine("Цифры сохранены в файл 'цифры.txt'");
        Console.WriteLine();

        // Чтение цифр из файла
        Console.WriteLine("Чтение цифр из файла 'цифры.txt':");

        using (StreamReader reader = new StreamReader("цифры.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (int.TryParse(line, out int number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        Console.WriteLine("Чтение завершено.");
    }
}
