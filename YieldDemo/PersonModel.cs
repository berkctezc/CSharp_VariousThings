namespace YieldDemo;

public class PersonModel
{
    public PersonModel(string name)
    {
        Name = name;
        Console.WriteLine($"initialized user {Name}");
    }

    public string Name { get; }
}