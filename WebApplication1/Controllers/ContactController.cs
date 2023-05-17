using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository<Contact> _contactRepository; // ici on a de l'inversion de contrôle, un couplage faible
        public ContactController(
            IRepository<Contact> contactRepository
            ) // injection des dépendances dans le ctor, elles sont récupérées depuis le conteneur de dépendances
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index() // index étant la page d'accueil de la partie Contact (localhost/Contact/) on pourra à l'avenir afficher nos contacts ici
        {
            var contactList = _contactRepository.GetAll(); // avec le repository

            return View(contactList);
        }

        public IActionResult Details(int id)
        {
            var contact = _contactRepository.Find(id); // avec le repository

            return View(contact);
        }

        public IActionResult FormulaireAjout()
        {
            return View("AddContact");
        }

        public IActionResult SubmitContact(Contact contact)
        {
            _contactRepository.Add(contact);

            return RedirectToAction("Index");
        }

        public IActionResult CreateRadom()
        {
            var contact = new Contact() 
            {
                FirstName = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 10),
                LastName = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 10),
                Email = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ-.", 10).ToLower() + "@" + RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ-.", 10).ToLower() + ".com",
                Phone = "+33" + RandomString("0123456789",9)
            };

            _contactRepository.Add(contact); // avec le repository

            return RedirectToAction("Index");
        }

        [NonAction] // empèche que cette méthode soit une action => il n'y aura pas de route /Contact/RandomString/
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IActionResult Delete(int id)
        {
            var contact = _contactRepository.Find(id); // avec le repository
            if (contact == null)
                return View("Error");

            _contactRepository.Remove(id); // avec le repository

            return RedirectToAction(nameof(Index));
        }
    }
}
