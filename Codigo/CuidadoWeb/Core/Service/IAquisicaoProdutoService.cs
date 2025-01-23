namespace Core.Service
{
	public interface IAquisicaoProdutoService
	{
		uint Create(AquisicaoProduto aquisicaoProduto);
		void Edit(AquisicaoProduto aquisicaoProduto);
		void Delete(int id);
		AquisicaoProduto? Get(int id);
	}
}
