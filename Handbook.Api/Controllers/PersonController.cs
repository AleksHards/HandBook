using Handbook.DTO;
using Handbook.Model;
using Handbook.Service;
using Handbook.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Handbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id:int}")]
        public Task<Person> GetPerson(int id)
        {
            return _personService.GetPerson(id) ?? throw new ArgumentNullException(nameof(id));
        }

        [HttpGet]
        public Task<IQueryable<Person>> GetPersons()
        {
            return _personService.GetAllPersons() ?? throw new ArgumentNullException($"Person {nameof(Person)} can not be loaded.");
        }

        [HttpPost]
        public Task CreatePerson(Person personModel) // TODO: აქ მოდელი უნდა გადმოიცეს.
        {
            _personService.AddPerson(new Person()
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                DateOfBirth = personModel.DateOfBirth,
                IdNumber = personModel.IdNumber,
            });
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task UpdatePerson(Person Person)
        {
            if (Person == null) throw new ArgumentNullException(nameof(Person));
            _personService.UpdatePerson(Person);
            return Task.CompletedTask;
        }

        [HttpDelete]
        public Task DeletePerson(int id)
        {
            _personService.DeletePerson(id);
            return Task.CompletedTask;
        }
    }
}
