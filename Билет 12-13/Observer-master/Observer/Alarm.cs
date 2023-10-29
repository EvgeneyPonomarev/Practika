using System.Collections.Generic;

namespace Observer
{
    public class Alarm : IObservable<Alarm>
    {
        List<IObserver<Alarm>> observers = new List<IObserver<Alarm>>();

        public void AddObserver(IObserver<Alarm> alarmObserver)
        {
            observers.Add(alarmObserver);
        }

        public void DeleteObserver(IObserver<Alarm> alarmObserver)
        { 
            observers.Remove(alarmObserver);
        }

        public void Notify()
        {
            foreach(var o in observers)
            {
                o.Alert(this);
            }
        }
    }
}
