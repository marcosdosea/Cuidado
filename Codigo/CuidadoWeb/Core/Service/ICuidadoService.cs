namespace Core.Service
{
	public interface ICuidadoService
	{
		uint Create(Cuidado cuidado);
		void Edit(Cuidado cuidado);
		void Delete(int id);
		Cuidado? Get(int id);
	}
}
