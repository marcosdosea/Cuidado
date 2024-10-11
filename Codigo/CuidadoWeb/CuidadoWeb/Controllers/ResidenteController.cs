using AutoMapper;
using Core;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
	public class ResidenteController : Controller
	{
		private readonly IResidenteService ResidenteService;
		private readonly IMapper mapper;

		public ResidenteController(IResidenteService ResidenteService, IMapper mapper)
		{
			this.ResidenteService = ResidenteService;
			this.mapper = mapper;
		}


		// GET: ResidenteController
		public ActionResult Index()
		{
			var listaResidentes = this.ResidenteService.GetAll();
			var listaResidentesModel = this.mapper.Map<List<ResidenteViewModel>>(listaResidentes);
			return View(listaResidentesModel);
		}

		// GET: ResidenteController/Details/5
		public ActionResult Details(int id)
		{
			Residente? Residente = this.ResidenteService.Get(id);
			ResidenteViewModel ResidenteModel = this.mapper.Map<ResidenteViewModel>(Residente);
			return View(ResidenteModel);
		}

		// GET: ResidenteController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ResidenteController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ResidenteViewModel ResidenteModel)
		{
			if (ModelState.IsValid)
			{
				var Residente = this.mapper.Map<Residente>(ResidenteModel);
				this.ResidenteService.Create(Residente);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ResidenteController/Edit/5
		public ActionResult Edit(int id)
		{
			Residente? Residente = this.ResidenteService.Get(id);
			ResidenteViewModel ResidenteModel = this.mapper.Map<ResidenteViewModel>(Residente);
			return View(ResidenteModel);
		}

		// POST: ResidenteController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, ResidenteViewModel ResidenteModel)
		{
			if (ModelState.IsValid)
			{
				var Residente = this.mapper.Map<Residente>(ResidenteModel);
				this.ResidenteService.Edit(Residente);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ResidenteController/Delete/5
		public ActionResult Delete(int id)
		{
			Residente? Residente = this.ResidenteService.Get(id);
			ResidenteViewModel ResidenteModel = this.mapper.Map<ResidenteViewModel>(Residente);
			return View(ResidenteModel);
		}

		// POST: ResidenteController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			this.ResidenteService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
