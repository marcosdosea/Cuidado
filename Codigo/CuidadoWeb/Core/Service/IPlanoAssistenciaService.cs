namespace Core.Service
{
	public interface IPlanoAssistenciaService
	{
		uint Create(PlanoAssistencia planoAssistencia);
		void Edit(PlanoAssistencia planoAssistencia);
		void Delete(int id);
		PlanoAssistencia? Get(int id);
	}
}
