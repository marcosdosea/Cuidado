namespace Core.Service
{
	public interface IFornecedorService
	{
		uint Create(Fornecedor fornecedor);
		void Edit(Fornecedor fornecedor);
		void Delete(int id);
		Fornecedor? Get(int id);
	}
}
