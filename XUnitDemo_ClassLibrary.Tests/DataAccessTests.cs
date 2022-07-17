namespace XUnitDemo_ClassLibrary.Tests;

public class DataAccessTests
{
    [Fact]
    public void AddPersonToPeopleList_ShouldWork()
    {
        var newPerson = new PersonModel {FirstName = "Berkcan", LastName = "Tezcaner"};
        var people = new List<PersonModel>();

        DataAccess.AddPersonToPeopleList(people, newPerson);

        Assert.True(people.Count == 1);
        Assert.Contains(newPerson, people);
    }

    [Theory]
    [InlineData("Berkcan", "", "LastName")]
    [InlineData("", "Tezcaner", "FirstName")]
    public void AddPersonToPeopleList_ShouldFail(string fName, string lName, string param)
    {
        var newPerson = new PersonModel {FirstName = fName, LastName = lName};
        var people = new List<PersonModel>();

        Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
    }

    [Fact]
    public void ConvertModelsToCSV_ShouldWork()
    {
        var newPerson1 = new PersonModel {FirstName = "asdfg", LastName = "sadfg"};
        var newPerson2 = new PersonModel {FirstName = "asd", LastName = "sadfdaswg"};
        var people = new List<PersonModel>();

        DataAccess.AddPersonToPeopleList(people, newPerson1);
        DataAccess.AddPersonToPeopleList(people, newPerson2);


        DataAccess.ConvertModelsToCSV(people);

        Assert.True(people.Count == 2);
        Assert.Contains(newPerson1, people);
    }
}