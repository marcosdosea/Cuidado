namespace Core.Service
{
	public interface IResidenteService
	{
		uint Create(Residente residente);
		void Edit(Residente residente);
		void Delete(int id);
		Residente? Get(int id);
	}
}
