namespace Core.Service
{
	public interface IOrganizacaoService
	{
		uint Create(Organizacao organizacao);
		void Edit(Organizacao organizacao);
		void Delete(int id);
		Organizacao? Get(int id);
	}
}
