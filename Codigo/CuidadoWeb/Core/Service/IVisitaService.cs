namespace Core.Service
{
	public interface IVisitaService
	{
		uint Create(Visita visita);
		void Edit(Visita visita);
		void Delete(int id);
		Visita? Get(int id);
	}
}
