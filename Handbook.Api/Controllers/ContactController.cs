using Handbook.DTO;
using Handbook.Model;
using Handbook.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Handbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService ContactService)
        {
            _contactService = ContactService;
        }

        [HttpGet("{id:int}")]
        public Task<Contact> GetContact(int id)
        {
            return _contactService.GetContact(id) ?? throw new ArgumentNullException(nameof(id));
        }

        [HttpGet]
        public Task<IQueryable<Contact>> GetContacts()
        {
            return _contactService.GetAllContacts() ?? throw new ArgumentNullException($"Contact {nameof(Contact)} can not be loaded.");
        }

        [HttpPost]
        public Task CreateContact(ContactModel ContactModel)
        {
            _contactService.AddContact(new Contact()
            {
                ContactInformation = ContactModel.ContactInfo,
            });
            return Task.CompletedTask;
        }

        [HttpPut]
        public Task UpdateContact(Contact Contact)
        {
            if (Contact == null) throw new ArgumentNullException(nameof(Contact));
            _contactService.UpdateContact(Contact);
            return Task.CompletedTask;
        }

        [HttpDelete]
        public Task DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return Task.CompletedTask;
        }
    }
}
