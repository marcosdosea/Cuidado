namespace Core.Service
{
	public interface ICuidadoService
	{
		int Create(Cuidado cuidado);
		void Edit(Cuidado cuidado);
		void Delete(int id);
		Cuidado? Get(int id);
		IEnumerable<Cuidado> GetAll();
	}
}
