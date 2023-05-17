using ApiHelper.Controllers;
using AutoMapper;
using demo_pizzeria.DTOs;
using demo_pizzeria.Helpers;
using demo_pizzeria.Models;
using EFHelper.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PizzaController : GenericController<Pizza, PizzaDTO>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;
        public PizzaController(IRepository<Pizza> pizzaRepository, IRepository<Ingredient> ingredientRepository, IMapper mapper) : base(pizzaRepository, mapper)
        {
            _ingredientRepository = ingredientRepository;
        }

        [Authorize(Roles = Constants.RoleAdmin)]
        public override Task<IActionResult> Post([FromBody] PizzaDTO entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = Constants.RoleAdmin)]
        public override Task<IActionResult> Put([FromRoute] object id, [FromBody] PizzaDTO entity)
        {
            return base.Put(id, entity);
        }

        [Authorize(Roles = Constants.RoleAdmin)]
        public override Task<IActionResult> Put([FromBody] PizzaDTO entity)
        {
            return base.Put(entity);
        }

        [Authorize(Roles = Constants.RoleAdmin)]
        public override IActionResult Remove([FromRoute] int id)
        {
            return base.Remove(id);
        }

        public override async Task<IActionResult> GetAll()
        {
            var pizzas = await _genericRepository.GetAllAsync();
            var pizzasDTO = new List<PizzaDTO>();
            pizzas.ForEach((Pizza pizza) =>
            {
                pizzasDTO.Add(_mapper.Map<Pizza, PizzaDTO>(pizza));
                pizzasDTO[^1].Ingredients = _mapper.Map<List<Ingredient>, List<IngredientDTO>>(pizza.Ingredients);
            });
            return Ok(pizzasDTO);
        }

        public override async Task<IActionResult> GetById([FromRoute] int id)
        {
            var pizza = await _genericRepository.FindAsync(id);
            if (pizza == null)
            {
                return NotFound(new { Message = "Pizza not found" });
            }
            var pizzaDTO = _mapper.Map<Pizza, PizzaDTO>(pizza);
            if (pizza.Ingredients.Count > 0)
                pizzaDTO.Ingredients = _mapper.Map<List<Ingredient>, List<IngredientDTO>>(pizza.Ingredients);
            return Ok(pizzaDTO);
        }

        [Authorize(Roles = Constants.RoleAdmin)]
        [Route("{pizzaId}")]
        [HttpPost]
        public async Task<IActionResult> AddIngredient([FromRoute] int pizzaId, [FromForm] IngredientDTO ingredientDTO)
        {
            var pizza = await _genericRepository.FindAsync(pizzaId);
            if (pizza == null)
            {
                return NotFound(new { Message = "Pizza not found" });
            }
            var ingredient = _mapper.Map<IngredientDTO, Ingredient>(ingredientDTO);
            ingredient.PizzaId = pizzaId;
            await _ingredientRepository.AddAsync(ingredient);
            var pizzaDTO = _mapper.Map<Pizza, PizzaDTO>(pizza);
            return Ok(new
            {
                Message = "Ajouté avec succès",
                Data = pizzaDTO
            });
        }

        [Authorize(Roles = Constants.RoleAdmin)]
        [Route("{pizzaId}/{toppingId}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveIngredient([FromRoute] int pizzaId, [FromRoute] int toppingId)
        {
            var pizza = await _genericRepository.FindAsync(pizzaId);
            if (pizza == null)
            {
                return NotFound(new { Message = "Pizza not found" });
            }
            var ingredient = pizza.Ingredients.Find(i => i.Id == toppingId);
            if (ingredient == null)
            {
                return NotFound(new { Message = "Topping not found" });
            }
            _ingredientRepository.Remove(ingredient.Id);
            var pizzaDTO = _mapper.Map<Pizza, PizzaDTO>(pizza);
            return Ok(new
            {
                Message = "Retiré avec succès",
                Data = pizza
            });
        }
    }
}
