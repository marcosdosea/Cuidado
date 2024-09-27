namespace Core.Service
{
	public interface IExameService
	{
		uint Create(Exame exame);
		void Edit(Exame exame);
		void Delete(int id);
		Exame? Get(int id);
	}
}
