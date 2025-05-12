public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest() => Console.WriteLine("Called SpecificRequest from Adaptee.");
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee = new();

    public void Request() => _adaptee.SpecificRequest();
}
