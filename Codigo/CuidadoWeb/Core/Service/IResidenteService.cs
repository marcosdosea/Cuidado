namespace Core.Service
{
	public interface IResidenteService
	{
		int Create(Residente residente);
		void Edit(Residente residente);
		void Delete(int id);
		Residente? Get(int id);
        IEnumerable<Residente> GetAll();
        IEnumerable<Residente> GetByNome(string nome);
    }
}
