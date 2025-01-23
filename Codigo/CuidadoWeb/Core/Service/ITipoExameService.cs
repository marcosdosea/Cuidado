namespace Core.Service
{
	public interface ITipoExameService
	{
		uint Create(TipoExame tipoExame);
		void Edit(TipoExame tipoExame);
		void Delete(int id);
		TipoExame? Get(int id);
	}
}
