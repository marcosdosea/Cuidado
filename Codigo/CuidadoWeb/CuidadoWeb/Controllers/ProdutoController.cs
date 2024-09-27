using AutoMapper;
using Core;
using Core.Service;
using CuidadoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuidadoWeb.Controllers
{
	public class ProdutoController : Controller
	{
		private readonly IProdutoService produtoService;
		private readonly IMapper mapper;

		public ProdutoController(IProdutoService produtoService, IMapper mapper)
		{
			this.produtoService = produtoService;
			this.mapper = mapper;
		}


		// GET: ProdutoController
		public ActionResult Index()
		{
			var listaProdutos = this.produtoService.GetAll();
			var listaProdutosModel = this.mapper.Map<List<ProdutoViewModel>>(listaProdutos);
			return View(listaProdutosModel);
		}

		// GET: ProdutoController/Details/5
		public ActionResult Details(int id)
		{
			Produto? produto = this.produtoService.Get(id);
			ProdutoViewModel produtoModel = this.mapper.Map<ProdutoViewModel>(produto);
			return View(produtoModel);
		}

		// GET: ProdutoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProdutoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ProdutoViewModel produtoModel)
		{
			if (ModelState.IsValid)
			{
				var produto = this.mapper.Map<Produto>(produtoModel);
				this.produtoService.Create(produto);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ProdutoController/Edit/5
		public ActionResult Edit(int id)
		{
			Produto? produto = this.produtoService.Get(id);
			ProdutoViewModel produtoModel = this.mapper.Map<ProdutoViewModel>(produto);
			return View(produtoModel);
		}

		// POST: ProdutoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, ProdutoViewModel produtoModel)
		{
			if (ModelState.IsValid)
			{
				var produto = this.mapper.Map<Produto>(produtoModel);
				this.produtoService.Edit(produto);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ProdutoController/Delete/5
		public ActionResult Delete(int id)
		{
			Produto? produto = this.produtoService.Get(id);
			ProdutoViewModel produtoModel = this.mapper.Map<ProdutoViewModel>(produto);
			return View(produtoModel);
		}

		// POST: ProdutoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, ProdutoViewModel produtoModel)
		{
			this.produtoService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
