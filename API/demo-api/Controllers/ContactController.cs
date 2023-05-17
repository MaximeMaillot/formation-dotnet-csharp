using demo_api.Data;
using demo_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using demo_api.Repositories;
using EFHelper.Interfaces;

namespace demo_api.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // api/contact
        // Get All
        [HttpGet]
        public IActionResult GetAll([FromQuery]string? name)
        {
            List<Contact> contacts;
            if (name != null)
            {
                contacts = _contactRepository.GetAll(c => c.FirstName.StartsWith(name));
            }
            else
            {
                contacts = _contactRepository.GetAll();
            }
            if (contacts.Any())
                return Ok(contacts);

            return NoContent();
        }

        // GET by id
        // api/contact/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _contactRepository.Find(id);
            if (contact != null)
                return Ok(contact);
            return NotFound(new
            {
                Message = "Contact not found !"
            });
        }


        // GET by name
        // api/contact/name/{name}
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var contacts = _contactRepository.GetAll(c => c.LastName == name || c.FirstName == name);
            if (contacts.Any())
            {
                return Ok(contacts);
            }
            return NotFound(new
            {
                Message = $"Contact with {name} not found !"
            });
        }

        // POST
        // api/contact
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            _contactRepository.Add(contact);
            return Ok("Contact ajouté");
        }

        // PUT
        // api/contact/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            if (contact.Id != id)
            {
                return BadRequest(new
                {
                    Message = $"Updated contact not correct !"
                });
            }
            if (!_contactRepository.Update(contact))
            {
                return NotFound(new
                {
                    Message = $"Contact with id {id} not found !"
                });
            }
            return Ok("Contact modifié");
        }

        // DELETE
        // api/contact/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_contactRepository.Remove(id))
            {
                return NotFound(new
                {
                    Message = $"Contact with id {id} not found !"
                });
            }
            return Ok("Contact supprimé");
        }
    }
}
