namespace Core.Service
{
	public interface IFonteRendaService
	{
		uint Create(FonteRenda fonteRenda);
		void Edit(FonteRenda fonteRenda);
		void Delete(int id);
		FonteRenda? Get(int id);
	}
}
