namespace Core.Service
{
	public interface IAquisicaoProdutoService
	{
		uint Create(Aquisicaoproduto aquisicaoProduto);
		void Edit(Aquisicaoproduto aquisicaoProduto);
		void Delete(int id);
		Aquisicaoproduto? Get(int id);
	}
}
