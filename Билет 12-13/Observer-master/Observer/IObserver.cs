namespace Observer
{
    public interface IObserver<T>
    {
        void Alert(T observer);
    }
}
