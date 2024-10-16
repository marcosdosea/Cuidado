namespace Core.Service
{
	public interface IEspecialidadeMedicinaService
	{
		uint Create(Especialidademedicina especialidadeMedicina);
		void Edit(Especialidademedicina especialidadeMedicina);
		void Delete(int id);
		Especialidademedicina? Get(int id);
	}
}
