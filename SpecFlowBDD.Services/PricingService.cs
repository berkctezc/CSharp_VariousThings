namespace SpecFlowBDD.Services;

public class PricingService : IPricingService
{
    public decimal GetBasketTotalAmount(Basket basket)
    {
        if (!basket.Products.Any())
            return 0;

        var basketValue = basket.Products.Sum(x => x.Price);

        if (basket.User!.IsLoggedIn)
            return basketValue - basketValue * 0.05m;

        return basketValue;
    }
}
