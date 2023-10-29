
//Напишите программу, получающую доступ ко всем кадрам стека и выводящие их содержимое на консоль
using System;
using System.Diagnostics;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Создаем объект StackTrace, который предоставляет информацию о стеке вызовов.
        StackTrace stackTrace = new StackTrace();

        // Получаем количество кадров стека вызовов.
        int frameCount = stackTrace.FrameCount;

        Console.WriteLine("Содержимое стека вызовов:");

        for (int i = 0; i < frameCount; i++)
        {
            // Получаем кадр стека по индексу.
            StackFrame stackFrame = stackTrace.GetFrame(i);

            // Получаем информацию о методе в данном кадре стека.
            MethodBase method = stackFrame.GetMethod();

            // Получаем информацию о файле и строке, где вызван данный метод (если доступно).
            string fileName = stackFrame.GetFileName();
            int lineNumber = stackFrame.GetFileLineNumber();

            Console.WriteLine($"Кадр стека #{i + 1}");
            Console.WriteLine($"Метод: {method.Name}");
            if (!string.IsNullOrEmpty(fileName) && lineNumber > 0)
            {
                Console.WriteLine($"Файл: {fileName}, Строка: {lineNumber}");
            }
            Console.WriteLine();
        }
    }
}




/* Запасной вариант 
using System;
using System.Diagnostics;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Создаем объект StackTrace
        StackTrace stackTrace = new StackTrace();

        // Получаем количество кадров стека
        int frameCount = stackTrace.FrameCount;

        Console.WriteLine("Содержимое всех кадров стека:");

        // Перебираем все кадры стека и выводим информацию о каждом из них
        for (int i = 0; i < frameCount; i++)
        {
            StackFrame frame = stackTrace.GetFrame(i);

            Console.WriteLine($"Кадр №{i + 1}:");

            // Выводим информацию о методе, в котором находится данный кадр стека
            MethodBase method = frame.GetMethod();
            if (method != null)
            {
                Console.WriteLine($"Метод: {method.Name}");
                Console.WriteLine($"Класс: {method.ReflectedType}");
            }

            // Выводим информацию о файле и строке кода
            Console.WriteLine($"Файл: {frame.GetFileName()}");
            Console.WriteLine($"Строка: {frame.GetFileLineNumber()}");
            Console.WriteLine();
        }
    }
}
 */