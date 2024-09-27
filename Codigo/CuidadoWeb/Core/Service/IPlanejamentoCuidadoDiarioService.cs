namespace Core.Service
{
	public interface IPlanejamentoCuidadoDiarioService
	{
		uint Create(Planejamentocuidadodiario planejamentoCuidadoDiario);
		void Edit(Planejamentocuidadodiario planejamentoCuidadoDiario);
		void Delete(int id);
		Planejamentocuidadodiario? Get(int id);
	}
}
