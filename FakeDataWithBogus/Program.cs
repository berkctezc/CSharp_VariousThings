Randomizer.Seed = new Random(420); // seed to generate same data always

var fakerBillingDetails = new Faker<BillingDetails>("es") // optional locale option
    .RuleFor(x => x.CustomerName, x => x.Person.FullName)
    .RuleFor(x => x.Email, x => x.Person.Email.ToLower())
    .RuleFor(
        x => x.Phone,
        x =>
            x.Person.Phone.Replace('.', ' ')
                .Replace('-', ' ')
                .Replace("x", "")
                .Replace("(", "")
                .Replace(")", "")
    )
    .RuleFor(x => x.City, x => x.Address.City())
    .RuleFor(x => x.Country, x => x.Address.Country())
    .RuleFor(x => x.AddressLine, x => x.Address.StreetAddress())
    .RuleFor(x => x.PostCode, x => x.Address.ZipCode());

var generatedBillingDetails = fakerBillingDetails.Generate(10);

foreach (var gbd in generatedBillingDetails)
    Console.WriteLine($"billing details: {JsonSerializer.Serialize(gbd)} \n");

var fakerOrder = new Faker<Order>()
    .RuleFor(x => x.Id, Guid.NewGuid)
    .RuleFor(x => x.ItemName, x => x.Lorem.Sentence(2))
    .RuleFor(x => x.Currency, x => x.Finance.Currency().Code)
    .RuleFor(x => x.Price, x => x.Finance.Amount(69, 420))
    .RuleFor(x => x.BillingDetails, x => fakerBillingDetails);

var generatedOrders = fakerOrder.Generate(10);

foreach (var go in generatedOrders)
    Console.WriteLine($"order: {JsonSerializer.Serialize(go)} \n");

/************************************/
Console.WriteLine("Generate Forever");
foreach (var f in fakerOrder.GenerateForever())
{
    Console.WriteLine(JsonSerializer.Serialize(f) + "\n");

    await Task.Delay(1000);
}
