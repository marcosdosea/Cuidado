﻿using AutoMapper;
using CuidadoWeb.Models;

namespace CuidadoWeb.Mappers
{
	public class ProdutoProfile : Profile
	{
		public ProdutoProfile() 
		{
			CreateMap<ProdutoViewModel, ProdutoViewModel>().ReverseMap();
		}
	}
}