
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Models;
using EFHelper.Interfaces;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        private readonly IRepository<Todo> _todoRepository; // ici on a de l'inversion de contrôle, un couplage faible
        public TodoController(
            IRepository<Todo> todoRepository
            ) // injection des dépendances dans le ctor, elles sont récupérées depuis le conteneur de dépendances
        {
            _todoRepository = todoRepository;
        }
        public IActionResult Index() // index étant la page d'accueil de la partie Contact (localhost/Contact/) on pourra à l'avenir afficher nos contacts ici
        {
            var todoList = _todoRepository.GetAll(); // avec le repository

            return View(todoList);
        }

        public IActionResult SubmitTodo(Todo todo)
        {
            _todoRepository.Add(todo);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeTodoStatus(int id)
        {
            Todo todo = _todoRepository.Find(id);
            todo.Status = !todo.Status;
            _todoRepository.Update(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _todoRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
