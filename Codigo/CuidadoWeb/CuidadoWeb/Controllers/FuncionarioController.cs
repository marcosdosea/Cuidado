using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CuidadoWeb.Controllers
{
	public class FuncionarioController : Controller
	{
		private readonly IFuncionarioService funcionarioService;
		private readonly IMapper mapper;

		public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
		{
			this.funcionarioService = funcionarioService;
			this.mapper = mapper;
		}


		// GET: FuncionarioController
		public ActionResult Index()
		{
			var listaFuncionarios = this.funcionarioService.GetAll();
			var listaFuncionariosModel = this.mapper.Map<List<FuncionarioViewModel>>(listaFuncionarios);
			return View(listaFuncionariosModel);
		}

		// GET: FuncionarioController/Details/5
		public ActionResult Details(int id)
		{
			Funcionario? funcionario = this.funcionarioService.Get(id);
			FuncionarioViewModel funcionarioModel = this.mapper.Map<FuncionarioViewModel>(funcionario);
			return View(funcionarioModel);
		}

		// GET: FuncionarioController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FuncionarioController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(FuncionarioViewModel funcionarioModel)
		{
			if (ModelState.IsValid)
			{
				var funcionario = this.mapper.Map<Funcionario>(funcionarioModel);
				this.funcionarioService.Create(funcionario);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: FuncionarioController/Edit/5
		public ActionResult Edit(int id)
		{
			Funcionario? funcionario = this.funcionarioService.Get(id);
			FuncionarioViewModel funcionarioModel = this.mapper.Map<FuncionarioViewModel>(funcionario);
			return View(funcionarioModel);
		}

		// POST: FuncionarioController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, FuncionarioViewModel funcionarioModel)
		{
			if (ModelState.IsValid)
			{
				var funcionario = this.mapper.Map<Funcionario>(funcionarioModel);
				this.funcionarioService.Edit(funcionario);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: FuncionarioController/Delete/5
		public ActionResult Delete(int id)
		{
			Funcionario? funcionario = this.funcionarioService.Get(id);
			FuncionarioViewModel funcionarioModel = this.mapper.Map<FuncionarioViewModel>(funcionario);
			return View(funcionarioModel);
		}

		// POST: FuncionarioController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, FuncionarioViewModel funcionarioModel)
		{
			this.funcionarioService.Delete(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> BuscarFuncionarioPorCpf(string cpf)
		{
			if (string.IsNullOrEmpty(cpf) || cpf.Length < 11)
			{
				return BadRequest("CPF inválido.");
			}
			var funcionario = await this.funcionarioService.BuscarFuncionarioPorCpf(cpf);
			if (funcionario == null)
			{
				return BadRequest("Funcionário não encontrado.");
			}
			var funcionarioModel = this.mapper.Map<FuncionarioViewModel>(funcionario);
			return PartialView("BuscarFuncionarioPorCpf", funcionarioModel);
		}
	}
}

