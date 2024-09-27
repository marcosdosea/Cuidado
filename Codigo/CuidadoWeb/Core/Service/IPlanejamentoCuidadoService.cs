namespace Core.Service
{
	public interface IPlanejamentoCuidadoService
	{
		uint Create(Planejamentocuidado planejamentoCuidado);
		void Edit(Planejamentocuidado planejamentoCuidado);
		void Delete(int id);
		Planejamentocuidado? Get(int id);
	}
}
