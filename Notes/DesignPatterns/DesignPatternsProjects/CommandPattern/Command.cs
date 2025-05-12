public interface ICommand
{
    void Execute();
}

public class Receiver
{
    public void Action() => Console.WriteLine("Receiver: Performing action.");
}

public class ConcreteCommand : ICommand
{
    private readonly Receiver _receiver;

    public ConcreteCommand(Receiver receiver) => _receiver = receiver;

    public void Execute() => _receiver.Action();
}
