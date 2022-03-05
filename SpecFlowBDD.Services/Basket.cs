namespace SpecFlowBDD.Services;

public class Basket
{
    public Basket()
    {
        Products = new List<Product>();
    }

    public List<Product> Products { get; init; }
    public User User { get; init; } = new();
}