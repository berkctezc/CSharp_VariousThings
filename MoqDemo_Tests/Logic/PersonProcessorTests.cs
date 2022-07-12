using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using Moq;
using MoqDemo_Library.Logic;
using MoqDemo_Library.Models;
using MoqDemo_Library.Utilities;
using Xunit;

namespace MoqDemo_Tests.Logic;

public class PersonProcessorTests
{
    [Theory]
    [InlineData("6'8\"", true, 80)]
    [InlineData("6\"8'", false, 0)]
    [InlineData("six'eight\"", false, 0)]
    public void ConvertHeightTextToInches_VariousOptions(
        string heightText,
        bool expectedIsValid,
        double expectedHeightInInches)
    {
        var processor = new PersonProcessor(null);

        var actual = processor.ConvertHeightTextToInches(heightText);

        Assert.Equal(expectedIsValid, actual.isValid);
        Assert.Equal(expectedHeightInInches, actual.heightInInches);
    }

    [Theory]
    [InlineData("Tom", "Column", "8'8\"", 104)]
    [InlineData("Poppers", "Pizza", "5'4\"", 64)]
    public void CreatePerson_Successful(string firstName, string lastName, string heightText, double expectedHeight)
    {
        var processor = new PersonProcessor(null);

        var expected = new PersonModel
        {
            FirstName = firstName,
            LastName = lastName,
            HeightInInches = expectedHeight,
            Id = 0
        };

        var actual = processor.CreatePerson(firstName, lastName, heightText);

        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.FirstName, actual.FirstName);
        Assert.Equal(expected.LastName, actual.LastName);
        Assert.Equal(expected.HeightInInches, actual.HeightInInches);
    }

    [Theory]
    [InlineData("Berkc#", "Tezc", "6'8\"", "firstName")]
    [InlineData("CBerry", "CTe2zcy", "5'4\"", "lastName")]
    [InlineData("Jimmy", "Nolan", "SixTwo", "heightText")]
    [InlineData("", "Murker", "5'11\"", "firstName")]
    public void CreatePerson_ThrowsException(string firstName, string lastName, string heightText, string expectedInvalidParameter)
    {
        var processor = new PersonProcessor(null);

        var ex = Record.Exception(() => processor.CreatePerson(firstName, lastName, heightText));

        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        if (ex is ArgumentException argEx) Assert.Equal(expectedInvalidParameter, argEx.ParamName);
    }

    [Fact]
    public void LoadPeople_ValidCall()
    {
        using var mock = AutoMock.GetLoose();
        mock.Mock<ISqliteDataAccess>()
            .Setup(x => x.LoadData<PersonModel>("select * from Person"))
            .Returns(GetSamplePeople());

        var cls = mock.Create<PersonProcessor>();
        var expected = GetSamplePeople();

        var actual = cls.LoadPeople();

        Assert.True(actual != null);
        Assert.Equal(expected.Count, actual.Count);

        for (var i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i].FirstName, actual[i].FirstName);
            Assert.Equal(expected[i].LastName, actual[i].LastName);
        }
    }

    [Fact]
    public void SavePeople_ValidCall()
    {
        using var mock = AutoMock.GetLoose();
        var person = new PersonModel
        {
            Id = 1,
            FirstName = "Berkcan",
            LastName = "Tezcaner",
            HeightInInches = 80
        };
        var sql = "insert into Person (FirstName, LastName, HeightInInches) " +
                  "values ('Berkcan', 'Tezcaner', 80)";

        mock.Mock<ISqliteDataAccess>()
            .Setup(x => x.SaveData(person, sql));

        var cls = mock.Create<PersonProcessor>();

        cls.SavePerson(person);

        mock.Mock<ISqliteDataAccess>()
            .Verify(x => x.SaveData(person, sql), Times.Exactly(1));
    }

    private List<PersonModel> GetSamplePeople()
    {
        var output = new List<PersonModel>
        {
            new()
            {
                FirstName = "AAA",
                LastName = "aaa"
            },
            new()
            {
                FirstName = "BBB",
                LastName = "bbb"
            }
        };
        return output;
    }
}