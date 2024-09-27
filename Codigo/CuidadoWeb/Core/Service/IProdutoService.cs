namespace Core.Service
{
	public interface IProdutoService
	{
		int Create(Produto produto);
		void Edit(Produto produto);
		void Delete(int id);
		Produto? Get(int id);
		IEnumerable<Produto> GetAll();
	}
}
