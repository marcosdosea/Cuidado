using AutoMapper;
using Core;
using CuidadoWeb.Models;

namespace CuidadoWeb.Mappers
{
	public class CuidadoProfile : Profile
	{
		public CuidadoProfile()
		{
			CreateMap<CuidadoViewModel, Cuidado>().ReverseMap();
		}
	}
}
