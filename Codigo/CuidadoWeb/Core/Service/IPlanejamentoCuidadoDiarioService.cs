namespace Core.Service
{
	public interface IPlanejamentoCuidadoDiarioService
	{
		uint Create(PlanejamentoCuidadoDiario planejamentoCuidadoDiario);
		void Edit(PlanejamentoCuidadoDiario planejamentoCuidadoDiario);
		void Delete(int id);
		PlanejamentoCuidadoDiario? Get(int id);
	}
}
