namespace Core.Service
{
	public interface IVisitaService
	{
		int Create(Visitum visita);
		void Edit(Visitum visita);
		void Delete(int id);
		Visitum? Get(int id);

        IEnumerable<Visitum> GetAll();
    }
}
