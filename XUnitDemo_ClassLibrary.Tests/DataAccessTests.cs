using System;
using System.Collections.Generic;
using Xunit;
using XUnitDemo_ClassLibrary.Models;

namespace XUnitDemo_ClassLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Berkcan", LastName = "Tezcaner" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains(newPerson, people);
        }

        [Theory]
        [InlineData("Berkcan", "", "LastName")]
        [InlineData("", "Tezcaner", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string fName, string lName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = fName, LastName = lName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldWork()
        {
            PersonModel newPerson1 = new PersonModel { FirstName = "asdfg", LastName = "sadfg" };
            PersonModel newPerson2 = new PersonModel { FirstName = "asd", LastName = "sadfdaswg" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson1);
            DataAccess.AddPersonToPeopleList(people, newPerson2);


            DataAccess.ConvertModelsToCSV(people);

            Assert.True(people.Count == 2);
            Assert.Contains(newPerson1,people);
        }
    }
}