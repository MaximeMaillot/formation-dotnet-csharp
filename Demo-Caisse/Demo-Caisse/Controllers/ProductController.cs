using Microsoft.AspNetCore.Mvc;
using Demo_Caisse.Models;
using EFHelper.Interfaces;
using Demo_Caisse.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Demo_Caisse.Services;
using System.Text.Json;

namespace Demo_Caisse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productRepository; // ici on a de l'inversion de contrôle, un couplage faible
        private readonly IRepository<Category> _categoryRepository; // ici on a de l'inversion de contrôle, un couplage faible
        private readonly IUploadService _uploadService;

        public ProductController(
            IRepository<Product> productRepository, IRepository<Category> categoryRepository, IUploadService uploadService
            ) // injection des dépendances dans le ctor, elles sont récupérées depuis le conteneur de dépendances
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _uploadService = uploadService;
        }

        public List<SelectListItem> constructCategorySelectListItem(List<Category> categories)
        {
            List<SelectListItem> categoriesSelect = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoriesSelect.Add(new SelectListItem(category.Name, category.Id.ToString()));
            };
            return categoriesSelect;
        }

        public IActionResult Index() // index étant la page d'accueil de la partie Contact (localhost/Contact/) on pourra à l'avenir afficher nos contacts ici
        {
            var categoryList = _productRepository.GetAll(); // avec le repository

            return View("Index", categoryList);
        }

        public IActionResult ShowDetails(int id)
        {
            var category = _productRepository.Find(id);

            return View("Details", category);
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.Find(id);
            _uploadService.Remove(product.ProductUrl);
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult FormAdd()
        {
            List<Category> categories = _categoryRepository.GetAll();

            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            //ViewBag.Categories = constructCategorySelectListItem(categories);

            return View("Update");
        }

        public IActionResult FormUpdate(int id)
        {
            List<Category> categories = _categoryRepository.GetAll();


            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            //ViewBag.Categories = constructCategorySelectListItem(categories);

            Product product = _productRepository.Find(id);

            return View("Update", product);
        }

        public IActionResult SubmitProduct(Product product, IFormFile productImg)
        {
            string filePath = _uploadService.Upload(productImg);
            if (filePath != null)
            {
                product.ProductUrl = filePath;
            }

            if (product.Id == 0)
            {
                _productRepository.Add(product);
            }
            else
            {
                _productRepository.Update(product);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cart()
        {
            var favList = _GetCart();

            var cartProductList = new Dictionary<Product, int>();



            foreach (var id in favList.ToList())
            {
                var contactFromDb = _productRepository.Find(id.Key);
                if (contactFromDb != null)
                    cartProductList[contactFromDb] = id.Value;
            }

            return View(cartProductList.ToList());
        }

        private Dictionary<int, int> _GetCart()
        {
            Dictionary<int, int> cartList = new Dictionary<int, int>();

            // Récupération d'un cookie
            //string? favCookie = HttpContext.Request.Cookies["favoris"]; // on récupère un cookie, sous forme de chaine de caractères (depuis la requête entrante)

            // Récupération d'une information dans la Session
            string? cartSession = HttpContext.Session.GetString("cart");

            if (cartSession != null)
            {
                cartList = JsonSerializer.Deserialize<Dictionary<int, int>>(cartSession)!; // on passe d'un string avec du json vers une List<int>
            }

            return cartList;
        }

        public IActionResult AddToCart(int id)
        {
            Dictionary<int, int> cartList = _GetCart(); // on récupère d'abord la liste de cookies

            if (!cartList.ContainsKey(id))
            {
                cartList.Add(id, 1);
            }
            else
            {
                cartList[id] += 1; // on ajoute un nouvel id de contact (nouveau favoris)
            }


            string cartCookie = JsonSerializer.Serialize(cartList); // on passe d'une List<int> vers un string avec du json

            // Set du cookie
            //HttpContext.Response.Cookies.Append("favoris", favCookie); // on définit le cookie

            // Set d'une information dans la Session
            HttpContext.Session.SetString("cart", cartCookie);

            return RedirectToAction(nameof(Index));
        }
    }
}
