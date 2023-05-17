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
    [Authorize(Roles = Constants.RoleAdmin)]
    public class UserController : GenericController<User, UserDTO>
    {
        public UserController(IRepository<User> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
