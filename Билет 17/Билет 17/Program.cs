//Напишите программу с плагинной архитектурой
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

// Интерфейс для всех плагинов
public interface IPlugin
{
    string Name { get; }
    void Execute();
}

// Основной класс программы
class Program
{
    static void Main()
    {
        List<IPlugin> plugins = LoadPlugins();

        if (plugins.Count == 0)
        {
            Console.WriteLine("Нет доступных плагинов.");
        }
        else
        {
            Console.WriteLine("Доступные плагины:");
            foreach (var plugin in plugins)
            {
                Console.WriteLine(plugin.Name);
            }

            Console.Write("Введите имя плагина для выполнения: ");
            string pluginName = Console.ReadLine();

            IPlugin selectedPlugin = plugins.FirstOrDefault(p => p.Name == pluginName);

            if (selectedPlugin != null)
            {
                selectedPlugin.Execute();
            }
            else
            {
                Console.WriteLine("Плагин с указанным именем не найден.");
            }
        }
    }

    static List<IPlugin> LoadPlugins()
    {
        List<IPlugin> plugins = new List<IPlugin>();
        string pluginPath = "Plugins"; // Директория с плагинами

        if (Directory.Exists(pluginPath))
        {
            string[] pluginFiles = Directory.GetFiles(pluginPath, "*.dll");

            foreach (string pluginFile in pluginFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(pluginFile);
                    Type[] types = assembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && type != typeof(IPlugin))
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при загрузке плагина из файла {pluginFile}: {ex.Message}");
                }
            }
        }
        return plugins;
    }
}