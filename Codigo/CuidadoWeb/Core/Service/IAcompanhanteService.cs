namespace Core.Service
{
	public interface IAcompanhanteService
	{
		uint Create(Acompanhante acompanhante);
		void Edit(Acompanhante acompanhante);
		void Delete(int id);
		Acompanhante? Get(int id);
	}
}
