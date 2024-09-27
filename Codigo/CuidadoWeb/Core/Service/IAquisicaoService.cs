namespace Core.Service
{
	public interface IAquisicaoService
	{
		uint Create(Aquisicao aquisicao);
		void Edit(Aquisicao aquisicao);
		void Delete(int id);
		Aquisicao? Get(int id);
	}
}
