namespace Core.Service
{
	public interface IPlanoAssistenciaService
	{
		uint Create(Planoassistencium planoAssistencia);
		void Edit(Planoassistencium planoAssistencia);
		void Delete(int id);
		Planoassistencium? Get(int id);
	}
}
