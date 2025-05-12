public interface IProduct
{
    void ShowDetails();
}

public record ProductA() : IProduct
{
    public void ShowDetails() => Console.WriteLine("Product A created.");
}

public record ProductB() : IProduct
{
    public void ShowDetails() => Console.WriteLine("Product B created.");
}

public static class ProductFactory
{
    public static IProduct CreateProduct(string type) =>
        type switch
        {
            "A" => new ProductA(),
            "B" => new ProductB(),
            _ => throw new ArgumentException("Invalid product type"),
        };
}
