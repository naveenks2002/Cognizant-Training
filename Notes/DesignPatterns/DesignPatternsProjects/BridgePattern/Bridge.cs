public interface IImplementation
{
    void Operation();
}

public class ConcreteImplementationA : IImplementation
{
    public void Operation() => Console.WriteLine("ConcreteImplementationA: Operation()");
}

public class ConcreteImplementationB : IImplementation
{
    public void Operation() => Console.WriteLine("ConcreteImplementationB: Operation()");
}

public class Abstraction
{
    private readonly IImplementation _implementation;

    public Abstraction(IImplementation implementation) => _implementation = implementation;

    public void Execute() => _implementation.Operation();
}
