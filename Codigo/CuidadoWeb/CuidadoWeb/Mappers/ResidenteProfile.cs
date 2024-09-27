using AutoMapper;
using CuidadoWeb.Models;

namespace CuidadoWeb.Mappers
{
	public class ResidenteProfile : Profile
	{
		public ResidenteProfile() 
		{
			CreateMap<ResidenteViewModel, ResidenteViewModel>().ReverseMap();
		}
	}
}
