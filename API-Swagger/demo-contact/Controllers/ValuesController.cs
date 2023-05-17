using ApiHelper.Controllers;
using AutoMapper;
using demo_contact.DTOs;
using demo_contact.Models;
using demo_contact.Repositories;
using EFHelper.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_contact.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : GenericController<Contact, ContactDTO>
    {
        public ValuesController(IRepository<Contact> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
