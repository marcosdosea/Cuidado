namespace Core.Service
{
	public interface ITipoCuidadoService
	{
		uint Create(TipoCuidado tipoCuidado);
		void Edit(TipoCuidado tipoCuidado);
		void Delete(int id);
		TipoCuidado? Get(int id);
	}
}
