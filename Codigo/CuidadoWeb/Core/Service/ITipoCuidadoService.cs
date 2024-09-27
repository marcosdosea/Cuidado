namespace Core.Service
{
	public interface ITipoCuidadoService
	{
		uint Create(Tipocuidado tipoCuidado);
		void Edit(Tipocuidado tipoCuidado);
		void Delete(int id);
		Tipocuidado? Get(int id);
	}
}
