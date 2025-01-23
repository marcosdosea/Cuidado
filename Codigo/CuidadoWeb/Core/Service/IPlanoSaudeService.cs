namespace Core.Service
{
	public interface IPlanoSaudeService
	{
		uint Create(PlanoSaude planoSaude);
		void Edit(PlanoSaude planoSaude);
		void Delete(int id);
		PlanoSaude? Get(int id);
	}
}
