using AutoMapper;
using Core;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
	public class VisitaController : Controller
	{
		private readonly IVisitaService VisitiaService;
		private readonly IMapper mapper;

		public VisitaController(IVisitaService VisitaService, IMapper mapper)
		{
			this.VisitaService = VisitaService;
			this.mapper = mapper;
		}


		// GET: VisitaController
		public ActionResult Index()
		{
			var listaVisitas = this.VisitaService.GetAll();
			var listaVisitasModel = this.mapper.Map<List<VisitaViewModel>>(listaVisitas);
			return View(listaVisitasModel);
		}

		// GET: VisitaController/Details/5
		public ActionResult Details(int id)
		{
            Visitum? Vista = this.VisitaService.Get(id);
			VisitaViewModel VisitaModel = this.mapper.Map<VisitaViewModel>(Visita);
			return View(VisitaModel);
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
			Visitum? Visita = this.VisitaService.Get(id);
            VisitaViewModel VisitaModel = this.mapper.Map<VisitaViewModel>(Visita);
			return View(VisitaModel);
		}

        // POST: VisitaController/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, VisitaViewModel Visita	Model)
		{
			if (ModelState.IsValid)
			{
				var Visita = this.mapper.Map<Visita>(VisitaModel);
				this.ResidenteService.Edit(Residente);
			}
			return RedirectToAction(nameof(Index));
		}

        // GET: VisitaController/Delete/5
        public ActionResult Delete(int id)
		{
            Visitum? Visita = this.VisitaService.Get(id);
            VisitaViewModel VisitaModel = this.mapper.Map<VisitaViewModel>(Visita);
			return View(VisitaModel);
		}

        // POST: VisitaController/Delete/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			this.VisitaService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
