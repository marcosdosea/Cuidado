namespace Core.Service
{
	public interface IPlanejamentoCuidadoService
	{
		uint Create(PlanejamentoCuidadoDiario planejamentoCuidado);
		void Edit(PlanejamentoCuidadoDiario planejamentoCuidado);
		void Delete(int id);
		PlanejamentoCuidadoDiario? Get(int id);
	}
}
