using AutoMapper;
using Core;
using CuidadoWeb.Models;

namespace CuidadoWeb.Mappers
{
	public class ResidenteProfile : Profile
	{
		public ResidenteProfile()
		{
			CreateMap<ResidenteViewModel, Residente>().ReverseMap();
		}
	}
}
