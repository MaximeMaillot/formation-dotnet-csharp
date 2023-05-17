
using Microsoft.AspNetCore.Mvc;
using Demo_Caisse.Models;
using EFHelper.Interfaces;

namespace Demo_Caisse.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryRepository; // ici on a de l'inversion de contrôle, un couplage faible
        public CategoryController(
            IRepository<Category> categoryRepository
            )
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index() // index étant la page d'accueil de la partie Contact (localhost/Contact/) on pourra à l'avenir afficher nos contacts ici
        {
            var categoryList = _categoryRepository.GetAll(); // avec le repository

            return View("Index", categoryList);
        }

        public IActionResult ShowDetails(int id)
        {
            var category = _categoryRepository.Find(id);

            return View("Details", category);
        }

        public IActionResult Delete(int id)
        {
            _categoryRepository.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult FormAdd()
        {
            return View("Update");
        }

        public IActionResult FormUpdate(int id)
        {
            var category = _categoryRepository.Find(id);

            return View("Update", category);
        }

        public IActionResult SubmitCategory(Category category)
        {
            if (category.Id == 0)
            {
                _categoryRepository.Add(category);
            }
            else
            {
                _categoryRepository.Update(category);
            }
            return RedirectToAction("Index");
        }
    }
}
