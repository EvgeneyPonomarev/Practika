using System;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alarm = new Alarm();

            PoliceStation ps = new PoliceStation();
            FireStation fs = new FireStation();

            alarm.AddObserver(ps);
            alarm.AddObserver(fs);
            alarm.Notify();

            Console.WriteLine("________________________________________");

            alarm.DeleteObserver(ps);
            alarm.Notify();
        }
    }
}
