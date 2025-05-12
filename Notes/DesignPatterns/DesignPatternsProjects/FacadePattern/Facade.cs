public class SubsystemA
{
    public void OperationA() => Console.WriteLine("SubsystemA: OperationA()");
}

public class SubsystemB
{
    public void OperationB() => Console.WriteLine("SubsystemB: OperationB()");
}

public class Facade
{
    private readonly SubsystemA _subA = new();
    private readonly SubsystemB _subB = new();

    public void Execute()
    {
        _subA.OperationA();
        _subB.OperationB();
    }
}
