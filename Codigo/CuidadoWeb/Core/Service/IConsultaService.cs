namespace Core.Service
{
	public interface IConsultaService
	{
		uint Create(Consulta consulta);
		void Edit(Consulta consulta);
		void Delete(int id);
		Consulta? Get(int id);
	}
}
