using AutoMapper;
using demo_pizzeria.DTOs;
using demo_pizzeria.Models;

namespace demo_pizzeria.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, RegisterRequestDTO>().ReverseMap();
            CreateMap<User, RegisterResponseDTO>().ReverseMap();
            CreateMap<User, LoginRequestDTO>().ReverseMap();
            CreateMap<User, LoginResponseDTO>().ReverseMap();
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
        }
    }
}
