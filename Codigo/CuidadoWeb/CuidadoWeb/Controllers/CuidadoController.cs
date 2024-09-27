using AutoMapper;
using Core;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
    public class CuidadoController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICuidadoService service;

        public CuidadoController(ICuidadoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: CuidadoController
        public ActionResult Index()
        {
            var listaCuidados = this.service.GetAll();
            var viewModel = this.mapper.Map<List<CuidadoViewModel>>(listaCuidados);

            return View(viewModel);
        }

        // GET: CuidadoController/Details/5
        public ActionResult Details(int id)
        {
            CuidadoViewModel? viewModel = null;
            Cuidado? cuidado = this.service.Get(id);

            if (cuidado == null)
                return NotFound();

            viewModel = this.mapper.Map<CuidadoViewModel>(cuidado);
            return View(viewModel);
        }

        // GET: CuidadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuidadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuidadoViewModel viewModel)
        {
            if (ModelState.IsValid) {
                var cuidado = this.mapper.Map<Cuidado>(viewModel);
                this.service.Create(cuidado);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CuidadoController/Edit/5
        public ActionResult Edit(int id)
        {
            CuidadoViewModel? viewModel = null;
            Cuidado? cuidado = this.service.Get(id);

            if (cuidado == null)
                return NotFound();

            viewModel = this.mapper.Map<CuidadoViewModel>(cuidado);
            return View(viewModel);
        }

        // POST: CuidadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CuidadoViewModel viewModel)
        {
            if (ModelState.IsValid) {
                var cuidado = this.mapper.Map<Cuidado>(viewModel);
                this.service.Edit(cuidado);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CuidadoController/Delete/5
        public ActionResult Delete(int id)
        {
            CuidadoViewModel? viewModel = null;
            Cuidado? cuidado = this.service.Get(id);

            if (cuidado == null)
                return NotFound();

            viewModel = this.mapper.Map<CuidadoViewModel>(cuidado);
            return View(viewModel);
        }

        // POST: CuidadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            this.service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
