using DemoContact.Data;
using DemoContact.Models;
using EFHelper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoContact.Controllers
{
    public class ContactController : Controller
    {
        public ContactDbContext _context;
        
        public ContactController(ContactDbContext context) { _context = context; }

        public IActionResult Index()
        {
            var contactRepository = new GenericRepository<Contact>(_context);
            List<Contact> contacts = contactRepository.GetAll();
            return View(contacts);
        }
        public IActionResult Details(int id)
        {
            var contactRepository = new GenericRepository<Contact>(_context);
            Contact contact = contactRepository.GetById(1);
            return View(contact);
        }

        public IActionResult Remove(int id)
        {
            var contactRepository = new GenericRepository<Contact>(_context);
            Contact contact = contactRepository.First();
            contactRepository.Remove(contact.Id);
            return RedirectToAction("Index");
        }

        public IActionResult AddContact()
        {
            return View();
        }
    }
}
