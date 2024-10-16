using AutoMapper;
using Core;
using CuidadoWeb.Models;


namespace CuidadoWeb.Mappers
{
    public class VisitanteProfile : Profile
    {
        public VisitanteProfile()
        {
            CreateMap<VisitanteViewModel, Visitante>().ReverseMap();
        }
    }
}
