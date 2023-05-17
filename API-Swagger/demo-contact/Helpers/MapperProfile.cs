using AutoMapper;
using demo_contact.DTOs;
using demo_contact.Models;

namespace demo_contact.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap(); //cette ligne permet de dire qu'a l'aide du mapper on pourra passer de l'entité vers le DTO
        }
    }
}
