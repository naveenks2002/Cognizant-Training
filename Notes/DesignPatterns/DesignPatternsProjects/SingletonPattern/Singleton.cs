public class Singleton
{
    private static Singleton? _instance;
    private static readonly object _lock = new();

    private Singleton() { }

    public static Singleton GetInstance()
    {
        lock (_lock)
        {
            return _instance ??= new Singleton();
        }
    }
}
