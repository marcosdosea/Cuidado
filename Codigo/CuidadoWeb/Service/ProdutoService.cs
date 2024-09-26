using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class ProdutoService : IProdutoService
	{
		private readonly CuidadoContext context;

		public ProdutoService(CuidadoContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Criar um novo produto na base dados
		/// </summary>
		/// <param name="produto">Dados do produto</param>
		/// <returns>Id do produto</returns>
		public int Create(Produto produto)
		{
			this.context.Add(produto);
			this.context.SaveChanges();
			return produto.Id;
		}

		/// <summary>s
		/// Remover o produto da base de dados
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			var produto = this.context.Produtos.Find(id);
			if(produto != null)
			{
				this.context.Remove(produto);
				this.context.SaveChanges();
			}
		}

		/// <summary>
		/// Editar dados do produto na base de dados
		/// </summary>
		/// <param name="produto"></param>
		public void Edit(Produto produto)
		{
			this.context.Update(produto);
			this.context.SaveChanges();
		}

		/// <summary>
		/// Buscar um produto na base de dados
		/// </summary>
		/// <param name="id">Id do produto</param>
		/// <returns>Dados do produto</returns>
		public Produto? Get(int id)
		{
			return this.context.Produtos.FirstOrDefault( a => a.Id == id);
		}

		public IEnumerable<Produto> GetAll()
		{
			return this.context.Produtos.AsNoTracking();
		}

	}
}
