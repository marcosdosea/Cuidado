namespace Core.Service
{
	public interface IVisitaService
	{
		uint Create(Visitum visita);
		void Edit(Visitum visita);
		void Delete(int id);
		Visitum? Get(int id);
	}
}
