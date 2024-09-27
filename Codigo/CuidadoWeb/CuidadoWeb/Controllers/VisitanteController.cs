using AutoMapper;
using Core;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
    public class VisitanteController : Controller
    {
        private readonly IVisitanteService visitanteService;
        private readonly IMapper mapper;

        public VisitanteController(IVisitanteService visitanteService, IMapper mapper)
        {
            this.visitanteService = visitanteService;
            this.mapper = mapper;
        }


        // GET: VisitanteController
        public ActionResult Index()
        {
            var listaVisitantes = this.visitanteService.GetAll();
            var listaVisitantesModel = this.mapper.Map<List<VisitanteViewModel>>(listaVisitantes);
            return View(listaVisitantesModel);
        }

        // GET: VisitanteController/Details/5
        public ActionResult Details(int id)
        {
            Visitante? visitante = this.visitanteService.Get(id);
            VisitanteViewModel visitanteModel = this.mapper.Map<VisitanteViewModel>(visitante);
            return View(visitanteModel);
        }

        // GET: VisitanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitanteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitanteViewModel visitanteModel)
        {
            if (ModelState.IsValid)
            {
                var visitante = this.mapper.Map<Visitante>(visitanteModel);
                this.visitanteService.Create(visitante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VisitanteController/Edit/5
        public ActionResult Edit(int id)
        {
            Visitante? visitante = this.visitanteService.Get(id);
            VisitanteViewModel visitanteModel = this.mapper.Map<VisitanteViewModel>(visitante);
            return View(visitanteModel);
        }

        // POST: VisitanteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VisitanteViewModel visitanteModel)
        {
            if (ModelState.IsValid)
            {
                var visitante = this.mapper.Map<Visitante>(visitanteModel);
                this.visitanteService.Edit(visitante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VisitanteController/Delete/5
        public ActionResult Delete(int id)
        {
            Visitante? visitante = this.visitanteService.Get(id);
            VisitanteViewModel visitanteModel = this.mapper.Map<VisitanteViewModel>(visitante);
            return View(visitanteModel);
        }

        // POST: VisitanteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VisitanteViewModel visitanteModel)
        {
            this.visitanteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
