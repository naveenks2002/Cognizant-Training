public interface IObserver
{
    void Update(string message);
}

public class ConcreteObserver : IObserver
{
    private readonly string _name;

    public ConcreteObserver(string name) => _name = name;

    public void Update(string message) => Console.WriteLine($"{_name} received update: {message}");
}

public class Subject
{
    private readonly List<IObserver> _observers = new();

    public void Attach(IObserver observer) => _observers.Add(observer);

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}
