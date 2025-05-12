public abstract class Handler
{
    protected Handler? _nextHandler;

    public void SetNext(Handler nextHandler) => _nextHandler = nextHandler;

    public virtual void HandleRequest(string request)
    {
        _nextHandler?.HandleRequest(request);
    }
}

public class ConcreteHandlerA : Handler
{
    public override void HandleRequest(string request)
    {
        if (request == "A") Console.WriteLine("ConcreteHandlerA handled request.");
        else base.HandleRequest(request);
    }
}

public class ConcreteHandlerB : Handler
{
    public override void HandleRequest(string request)
    {
        if (request == "B") Console.WriteLine("ConcreteHandlerB handled request.");
        else base.HandleRequest(request);
    }
}
