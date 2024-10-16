namespace Core.Service
{
	public interface IFornecedorOrganizacaoService
	{
		uint Create(Fornecedororganizacao fornecedorOrganizacao);
		void Edit(Fornecedororganizacao fornecedorOrganizacao);
		void Delete(int id);
		Fornecedororganizacao? Get(int id);
	}
}
