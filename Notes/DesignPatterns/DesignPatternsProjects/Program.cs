class Program
{
    static void Main()
    {
        Console.WriteLine("Design Patterns Showcase 🚀");

        // Factory Pattern
        var product = ProductFactory.CreateProduct("A");
        product.ShowDetails();

        // Singleton Pattern
        var singleton1 = Singleton.GetInstance();
        var singleton2 = Singleton.GetInstance();
        Console.WriteLine($"Singleton instances are same: {singleton1 == singleton2}");

        // Adapter Pattern
        ITarget adapter = new Adapter();
        adapter.Request();

        // Bridge Pattern
        var bridge = new Abstraction(new ConcreteImplementationA());
        bridge.Execute();

        // Facade Pattern
        var facade = new Facade();
        facade.Execute();

        // Chain of Responsibility
        var handlerA = new ConcreteHandlerA();
        var handlerB = new ConcreteHandlerB();
        handlerA.SetNext(handlerB);
        handlerA.HandleRequest("B");

        // Command Pattern
        var receiver = new Receiver();
        var command = new ConcreteCommand(receiver);
        command.Execute();

        // Observer Pattern
        var subject = new Subject();
        var observer1 = new ConcreteObserver("Observer 1");
        var observer2 = new ConcreteObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);
        subject.Notify("New Update Available!");
    }
}
