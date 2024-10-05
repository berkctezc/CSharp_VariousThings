namespace SpecFlowBDD.Tests.Behavior.Steps;

[Binding]
public class LoggedInDiscountSteps
{
    private readonly IPricingService _pricingService = new PricingService();
    private Basket _basket = new();
    private User? _user;

    [Given(@"a user that is not logged in")]
    public void GivenAUserThatIsNotLoggedIn()
    {
        _user = new User { IsLoggedIn = false };
    }

    [Given(@"an empty basket")]
    public void GivenAnEmptyBasket()
    {
        _basket = new Basket { User = _user };
    }

    [When(@"a (.*) that costs (.*) GBP is added to the basket")]
    public void WhenAThatCostsGbpIsAddedToTheBasket(string itemName, decimal price)
    {
        _basket.Products.Add(new Product { Name = itemName, Price = price });
    }

    [Then(@"the basket value is (.*) GBP")]
    public void ThenTheBasketValueIsGbp(decimal expected)
    {
        var basketValue = _pricingService.GetBasketTotalAmount(_basket);
        basketValue.Should().Be(expected);
    }

    [Given(@"a user that is logged in")]
    public void GivenAUserThatIsLoggedIn()
    {
        _user = new User { IsLoggedIn = true };
    }
}
