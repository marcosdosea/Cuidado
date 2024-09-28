using AutoMapper;
using Core;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
    public class VisitaController : Controller
    {
        private readonly IVisitaService VisitaService;
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
            Visita? Visita = this.VisitaService.Get(id);
            VisitaViewModel VisitaModel = this.mapper.Map<VisitaViewModel>(Visita);
            return View(VisitaModel);
        }

        // GET: VisitaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitaViewModel VisitaModel)
        {
            if (ModelState.IsValid)
            {
                var Visita = this.mapper.Map<Visita>(VisitaModel);
                this.VisitaService.Create(Visita);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VisitaController/Edit/5
        public ActionResult Edit(int id)
        {
            Visita? Visita = this.VisitaService.Get(id);
            VisitaViewModel VisitaModel = this.mapper.Map<VisitaViewModel>(Visita);
            return View(VisitaModel);
        }

        // POST: VisitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VisitaViewModel VisitaModel)
        {
            if (ModelState.IsValid)
            {
                var Visita = this.mapper.Map<Visita>(VisitaModel);
                this.VisitaService.Edit(Visita);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VisitaController/Delete/5
        public ActionResult Delete(int id)
        {
            Visita? Visita = this.VisitaService.Get(id);
            VisitaViewModel VisitaModel = this.mapper.Map<VisitaViewModel>(Visita);
            return View(VisitaModel);
        }

        // POST: VisitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VisitaViewModel VisitaModel)
        {
            this.VisitaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
