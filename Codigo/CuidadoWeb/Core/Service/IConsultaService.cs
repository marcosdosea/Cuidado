namespace Core.Service
{
	public interface IConsultaService
	{
		uint Create(Consultum consulta);
		void Edit(Consultum consulta);
		void Delete(int id);
		Consultum? Get(int id);
	}
}
