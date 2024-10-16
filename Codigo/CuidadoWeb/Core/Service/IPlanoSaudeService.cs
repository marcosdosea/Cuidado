namespace Core.Service
{
	public interface IPlanoSaudeService
	{
		uint Create(Planosaude planoSaude);
		void Edit(Planosaude planoSaude);
		void Delete(int id);
		Planosaude? Get(int id);
	}
}
