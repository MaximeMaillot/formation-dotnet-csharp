using ApiHelper.Controllers;
using AutoMapper;
using demo_pizzeria.DTOs;
using demo_pizzeria.Helpers;
using demo_pizzeria.Models;
using EFHelper.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace demo_pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientController : GenericController<Ingredient, IngredientDTO>
    {
        public IngredientController(IRepository<Ingredient> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
        [Authorize(Roles = Constants.RoleAdmin)]
        public override Task<IActionResult> Put([FromBody] IngredientDTO entity)
        {
            return base.Put(entity);
        }
        [Authorize(Roles = Constants.RoleAdmin)]
        public override Task<IActionResult> Put([FromRoute] object id, [FromBody] IngredientDTO entity)
        {
            return base.Put(id, entity);
        }
        [Authorize(Roles = Constants.RoleAdmin)]
        public override Task<IActionResult> Post([FromBody] IngredientDTO entity)
        {
            return base.Post(entity);
        }
        [Authorize(Roles = Constants.RoleAdmin)]
        public override IActionResult Remove([FromRoute] int id)
        {
            return base.Remove(id);
        }
    }
}
