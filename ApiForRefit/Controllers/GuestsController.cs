using ApiForRefit.Models;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace ApiForRefit.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestsController : ControllerBase
{
    private static readonly Faker<GuestModel?> Faker = new Faker<GuestModel?>()
        .RuleFor(x => x.FullName, x => x.Person.FullName)
        .RuleFor(x => x.Id, x => x.IndexFaker);

    private static readonly List<GuestModel?> Guests = Faker.Generate(20);

    // GET: api/<GuestsController>
    [HttpGet]
    public IEnumerable<GuestModel?> Get()
    {
        return Guests;
    }

    // GET api/<GuestsController>/5
    [HttpGet("{id}")]
    public GuestModel? Get(int id)
    {
        return Guests.FirstOrDefault(g => g.Id == id);
    }

    // POST api/<GuestsController>
    [HttpPost]
    public void Post([FromBody] GuestModel? value)
    {
        Guests.Add(value);
    }

    // PUT api/<GuestsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] GuestModel? value)
    {
        Guests.Remove(Guests.FirstOrDefault(g => g.Id == id));
        Guests.Add(value);
    }

    // DELETE api/<GuestsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        Guests.Remove(Guests.FirstOrDefault(g => g.Id == id));
    }
}