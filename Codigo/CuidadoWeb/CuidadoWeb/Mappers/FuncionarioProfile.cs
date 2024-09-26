using AutoMapper;
using Core;
using CuidadoWeb.Models;

namespace CuidadoWeb.Mappers
{
	public class FuncionarioProfile : Profile
	{
		public FuncionarioProfile()
		{
			CreateMap<FuncionarioViewModel, Funcionario>().ReverseMap();
		}
	}
}
