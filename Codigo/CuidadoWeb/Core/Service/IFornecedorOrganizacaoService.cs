namespace Core.Service
{
	public interface IFornecedorOrganizacaoService
	{
		uint Create(FornecedorOrganizacao fornecedorOrganizacao);
		void Edit(FornecedorOrganizacao fornecedorOrganizacao);
		void Delete(int id);
		FornecedorOrganizacao? Get(int id);
	}
}
