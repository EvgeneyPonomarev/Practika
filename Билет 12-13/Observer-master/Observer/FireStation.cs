using System;

namespace Observer
{
    public class FireStation : IObserver<Alarm>
    {
        public void Alert(Alarm value)
        {
            Console.WriteLine("В ПОЖАРКЕ СРАБОТАЛА СИГНАЛИЗАЦИЯ!");
        }
    }
}
