using System;

namespace Observer
{
    public class PoliceStation : IObserver<Alarm>
    { 
        public void Alert(Alarm value)
        {
            Console.WriteLine("В ПОЛИЦИИ СРАБОТАЛА СИГНАЛИЗАЦИЯ!");
        }
    }
}
