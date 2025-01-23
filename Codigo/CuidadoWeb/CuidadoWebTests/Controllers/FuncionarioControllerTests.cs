using Moq;
using AutoMapper;
using Core.Service;
using CuidadoWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using CuidadoWeb.Models;
using Core.DTO;

namespace CuidadoWeb.Controllers.Tests
{
	[TestClass()]
	public class FuncionarioControllerTests
	{
		private static FuncionarioController? controller;

		[TestInitialize]
		public void Initialize()
		{
			var mockService = new Mock<IFuncionarioService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new FuncionarioProfile())).CreateMapper();

			mockService.Setup(service => service.GetAll())
				.Returns(GetTestFuncionarios());
			mockService.Setup(service => service.Get(1))
				.Returns(GetTargetFuncionario());

			mockService.Setup(service => service.Edit(It.IsAny<Funcionario>()))
				.Verifiable();
			mockService.Setup(service => service.Create(It.IsAny<Funcionario>()))
				.Verifiable();
			controller = new FuncionarioController(mockService.Object, mapper);
		}

		[TestMethod()]
		[TestCategory("Unit")]
		[Description("Testando o Index")]
		public void IndexTest()
		{
			// Act
			var result = controller!.Index();
			// Assert
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<FuncionarioViewModel>));
			List<FuncionarioViewModel> lista = (List<FuncionarioViewModel>)viewResult.ViewData.Model;
			Assert.AreEqual(3, lista.Count);
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller!.Details(1);
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FuncionarioViewModel));
			FuncionarioViewModel funcionarioViewModel = (FuncionarioViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Guilherme Lima Santos", funcionarioViewModel.Nome);
			Assert.AreEqual(DateTime.Parse("2001-10-17"), funcionarioViewModel.DataNascimento);
		}

		[TestMethod()]
		public void CreateTest()
		{
			// Act
			var result = controller!.Create();
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod()]
		public void CreateTest1()
		{
			// Act
			var result = controller!.Create(GetTargetFuncionarioViewModel());
			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void EditTest()
		{
			// Act
			var result = controller!.Edit(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FuncionarioViewModel));
			FuncionarioViewModel funcionarioViewModel = (FuncionarioViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Guilherme Lima Santos", funcionarioViewModel.Nome);
			Assert.AreEqual(DateTime.Parse("2001-10-17"), funcionarioViewModel.DataNascimento);
		}

		[TestMethod()]
		public void EditTest1()
		{
			// Act
			var result = controller!.Edit(GetTargetFuncionarioViewModel().Id, GetTargetFuncionarioViewModel());
			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			// Act
			var result = controller!.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FuncionarioViewModel));
			FuncionarioViewModel funcionarioViewModel = (FuncionarioViewModel)viewResult.ViewData.Model;
			Assert.AreEqual("Guilherme Lima Santos", funcionarioViewModel.Nome);
			Assert.AreEqual(DateTime.Parse("2001-10-17"), funcionarioViewModel.DataNascimento);
		}

		[TestMethod()]
		public void DeleteTest1()
		{
			// Act
			var result = controller!.Delete(GetTargetFuncionarioViewModel().Id, GetTargetFuncionarioViewModel());
			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static FuncionarioViewModel GetTargetFuncionarioViewModel()
		{
			return new FuncionarioViewModel
			{
				Id = 1,
				Nome = "Guilherme Lima Santos",
				Cpf = "003.336.119-82",
				DataNascimento = DateTime.Parse("2001-10-17"),
				DataAdmissao = DateTime.Parse("2018-01-01"),
				Cargo = "Cuidador",
				Status = "Ativo",
				Salario = 4200.00m,
				NumeroCasa = 15,
				IdentificadorCasa = "A",
				Rua = "Rua dos Escritores",
				Bairro = "Centro",
				Cidade = "Itabaiana",
				Estado = "SE",
				Cep = 49500511,
				Complemento = "",
				PrimeiroTelefone = "(79) 99919-0056",
				SegundoTelefone = "",
				IdOrganizacao = 1
			};

		}

		private static Funcionario GetTargetFuncionario()
		{
			return new Funcionario
			{
				Id = 1,
				Nome = "Guilherme Lima Santos",
				Cpf = "003.336.119-82",
				DataNascimento = DateOnly.Parse("2001-10-17"),
				DataAdmissao = DateOnly.Parse("2018-01-01"),
				Cargo = "Cuidador",
				Status = "Ativo",
				Salario = 4200.00m,
				NumeroCasa = 15,
				IdentificadorCasa = "A",
				Rua = "Rua dos Escritores",
				Bairro = "Centro",
				Cidade = "Itabaiana",
				Estado = "SE",
				Cep = 49500511,
				Complemento = "",
				PrimeiroTelefone = "(79) 99919-0056",
				SegundoTelefone = "",
				IdOrganizacao = 1
			};
		}

		private static IEnumerable<Funcionario> GetTestFuncionarios()
		{
			return new List<Funcionario>
			{
				new Funcionario
				{
					Id = 1,
					Nome = "Cleide Ramos da Silva",
					Cpf = "123.456.789-00",
					DataNascimento = DateOnly.Parse("1992-10-27"),
					DataAdmissao = DateOnly.Parse("2015-01-01"),
					Cargo = "Faxineira",
					Status = "Ativo",
					Salario = 3100.00m,
					NumeroCasa = 11,
					IdentificadorCasa = "A",
					Rua = "Rua dos Escritores",
					Bairro = "Centro",
					Cidade = "Itabaiana",
					Estado = "SE",
					Cep = 49500511,
					Complemento = "Apartamento 201",
					PrimeiroTelefone = "(79) 99919-4678",
					SegundoTelefone = "(79) 98005-4321",
					IdOrganizacao = 1
				},
				new Funcionario
				{
					Id = 3,
					Nome = "Paulo Ramos da Costa",
					Cpf = "123.456.700-00",
					DataNascimento = DateOnly.Parse("1990-08-02"),
					DataAdmissao = DateOnly.Parse("2020-01-01"),
					Cargo = "Zelador",
					Status = "Ativo",
					Salario = 3100.00m,
					NumeroCasa = 26,
					IdentificadorCasa = "A",
					Rua = "Rua das Flores",
					Bairro = "Centro",
					Cidade = "Itabaiana",
					Estado = "SE",
					Cep = 49500501,
					Complemento = "",
					PrimeiroTelefone = "(79) 99919-4678",
					SegundoTelefone = "",
					IdOrganizacao = 1
				},
				new Funcionario
				{
					Id = 4,
					Nome = "Gildete da Silva Matos",
					Cpf = "024.456.700-00",
					DataNascimento = DateOnly.Parse("2000-10-02"),
					DataAdmissao = DateOnly.Parse("2021-01-01"),
					Cargo = "Cuidadora",
					Status = "Ativo",
					Salario = 4200.00m,
					NumeroCasa = 12,
					IdentificadorCasa = "A",
					Rua = "Rua dos Jarros",
					Bairro = "Centro",
					Cidade = "Itabaiana",
					Estado = "SE",
					Cep = 49500512,
					Complemento = "",
					PrimeiroTelefone = "(79) 99919-5578",
					SegundoTelefone = "",
					IdOrganizacao = 1
				},
			};
		}
	}
}
