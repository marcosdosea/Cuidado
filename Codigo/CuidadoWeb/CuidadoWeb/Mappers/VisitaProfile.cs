using AutoMapper;
using Core;
using CuidadoWeb.Models;


namespace CuidadoWeb.Mappers
{
    public class VisitaProfile : Profile
    {
        public VisitaProfile()
        {
            CreateMap<VisitaViewModel, Visitum>().ReverseMap();
        }
    }
}
