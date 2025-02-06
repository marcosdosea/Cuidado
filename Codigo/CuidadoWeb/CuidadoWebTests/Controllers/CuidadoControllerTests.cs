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
	public class CuidadoControllerTests
	{
		private static CuidadoController? controller;

		[TestInitialize]
		public void Initialize()
		{
			var mockService = new Mock<ICuidadoService>();

			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new CuidadoProfile())).CreateMapper();

			mockService.Setup(service => service.GetAll())
				.Returns(GetTestCuidados());
			mockService.Setup(service => service.Get(1))
				.Returns(GetTargetCuidado());

			mockService.Setup(service => service.Edit(It.IsAny<Cuidado>()))
				.Verifiable();
			mockService.Setup(service => service.Create(It.IsAny<Cuidado>()))
				.Verifiable();
			controller = new CuidadoController(mockService.Object, mapper);
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CuidadoViewModel>));
			List<CuidadoViewModel> lista = (List<CuidadoViewModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CuidadoViewModel));
			CuidadoViewModel cuidadoViewModel = (CuidadoViewModel)viewResult.ViewData.Model;
			Assert.AreEqual(1, cuidadoViewModel.IdResidente);
			Assert.AreEqual(DateTime.Parse("2024-11-26 10:00:00"), cuidadoViewModel.DataExecucao);
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
			var result = controller!.Create(GetTargetCuidadoViewModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult) result;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CuidadoViewModel));
			CuidadoViewModel cuidadoViewModel = (CuidadoViewModel)viewResult.ViewData.Model;
			Assert.AreEqual(1, cuidadoViewModel.IdResidente);
			Assert.AreEqual(DateTime.Parse("2024-11-26 10:00:00"), cuidadoViewModel.DataExecucao);
		}

		[TestMethod()]
		public void EditTest1()
		{
			// Act
			var result = controller!.Edit(GetTargetCuidadoViewModel().Id, GetTargetCuidadoViewModel());
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CuidadoViewModel));
			CuidadoViewModel cuidadoViewModel = (CuidadoViewModel)viewResult.ViewData.Model;
			Assert.AreEqual(1, cuidadoViewModel.IdResidente);
			Assert.AreEqual(DateTime.Parse("2024-11-26 10:00:00"), cuidadoViewModel.DataExecucao);
		}

		[TestMethod()]
		public void DeleteTest1()
		{
			// Act
			var result = controller!.Delete(GetTargetCuidadoViewModel().Id, GetTargetCuidadoViewModel());
			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static CuidadoViewModel GetTargetCuidadoViewModel()
		{
			return new CuidadoViewModel
			{
				Id = 1,
				DataExecucao = DateTime.Parse("2001-10-17 00:00:00"),
                IdResidente = 1,
                IdFuncionario = 1,
                IdPlanejamentoCuidado = 1,
			};
		}

		private static Cuidado GetTargetCuidado()
		{
			return new Cuidado
			{
				Id = 1,
				DataExecucao = DateTime.Parse("2024-11-26 10:00:00"),
                IdResidente = 1,
                IdFuncionario = 1,
                IdPlanejamentoCuidado = 1,
			};
		}

		private static IEnumerable<Cuidado> GetTestCuidados()
		{
			return new List<Cuidado>
			{
				new Cuidado
                {
                    Id = 1,
                    DataExecucao = DateTime.Parse("2025-01-01 00:00:00"),
                    IdResidente = 10,
                    IdFuncionario = 10,
                    IdPlanejamentoCuidado = 2,
                },
                new Cuidado
                {
                    Id = 2,
                    DataExecucao = DateTime.Parse("2023-05-17 12:37:00"),
                    IdResidente = 22,
                    IdFuncionario = 2,
                    IdPlanejamentoCuidado = 5,
                },
                new Cuidado
                {
                    Id = 3,
                    DataExecucao = DateTime.Parse("2024-12-28 18:28:00"),
                    IdResidente = 50,
                    IdFuncionario = 10,
                    IdPlanejamentoCuidado = 5,
                },
			};
		}
	}
}
