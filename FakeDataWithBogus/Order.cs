namespace FakeDataWithBogus;

public class Order
{
    public Guid Id { get; set; }
    public string ItemName { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public BillingDetails BillingDetails { get; set; }
}