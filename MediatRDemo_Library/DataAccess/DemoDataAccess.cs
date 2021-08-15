using System.Collections.Generic;
using System.Linq;
using MediatRDemo_Library.Models;

namespace MediatRDemo_Library.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new List<PersonModel>();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "David", LastName = "Bowie" });
            people.Add(new PersonModel { Id = 2, FirstName = "Angus", LastName = "Young" });
        }

        public List<PersonModel> GetPeople()
        {
            // use normal dataaccess methods here dapper, ef ...
            return people;
        }

        public PersonModel InsertPerson(string fname, string lname)
        {
            PersonModel personToCreate = new PersonModel() { FirstName = fname, LastName = lname };
            personToCreate.Id = people.Max(x => x.Id) + 1;
            people.Add(personToCreate);

            return personToCreate;
        }
    }
}
