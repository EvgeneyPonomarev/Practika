namespace Observer
{
    public interface IObservable<T>
    {
        void AddObserver(IObserver<T> observer);
        void DeleteObserver(IObserver<T> observer);
        void Notify();
    }
}
