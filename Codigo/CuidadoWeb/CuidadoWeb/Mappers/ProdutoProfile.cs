using AutoMapper;
using Core;
using CuidadoWeb.Models;

namespace CuidadoWeb.Mappers
{
	public class ProdutoProfile : Profile
	{
		public ProdutoProfile() 
		{
			CreateMap<ProdutoViewModel, Produto>().ReverseMap();
		}
	}
}
