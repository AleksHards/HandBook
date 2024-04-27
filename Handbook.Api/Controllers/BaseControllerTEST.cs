using Handbook.DTO;
using Handbook.Model;
using Handbook.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

//namespace Handbook.Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class BaseController<T> : ControllerBase
//    {
//        private readonly T _baseService;

//        public BaseController(T personService)
//        {
//            _baseService = personService;
//        }

//        [HttpGet("{id:int}")]
//        public Task<Person> Get(int id)
//        {
//            return _baseService.Get(id) ?? throw new ArgumentNullException(nameof(id));
//        }

//        [HttpGet]
//        public Task<IQueryable<Person>> GetPersons()
//        {
//            return _baseService.GetAllPersons() ?? throw new ArgumentNullException($"Person {nameof(Person)} can not be loaded.");
//        }

//        [HttpPost]
//        public Task CreatePerson(PersonModel personModel)
//        {
//            _baseService.AddPerson(new Person()
//            {
//                FirstName = personModel.FirstName,
//                LastName = personModel.LastName,
//                DateOfBirth = personModel.DateOfBirth,
//                IdNumber = personModel.IdNumber,
//            });
//            return Task.CompletedTask;
//        }

//        [HttpPut]
//        public Task UpdatePerson(Person Person)
//        {
//            if (Person == null) throw new ArgumentNullException(nameof(Person));
//            _baseService.UpdatePerson(Person);
//            return Task.CompletedTask;
//        }

//        [HttpDelete]
//        public Task DeletePerson(int id)
//        {
//            _baseService.DeletePerson(id);
//            return Task.CompletedTask;
//        }
//    }
//}
