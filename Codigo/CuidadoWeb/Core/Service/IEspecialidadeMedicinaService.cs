namespace Core.Service
{
	public interface IEspecialidadeMedicinaService
	{
		uint Create(EspecialidadeMedicina especialidadeMedicina);
		void Edit(EspecialidadeMedicina especialidadeMedicina);
		void Delete(int id);
		EspecialidadeMedicina? Get(int id);
	}
}
