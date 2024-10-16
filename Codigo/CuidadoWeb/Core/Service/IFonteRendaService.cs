namespace Core.Service
{
	public interface IFonteRendaService
	{
		uint Create(Fonterendum fonteRenda);
		void Edit(Fonterendum fonteRenda);
		void Delete(int id);
		Fonterendum? Get(int id);
	}
}
