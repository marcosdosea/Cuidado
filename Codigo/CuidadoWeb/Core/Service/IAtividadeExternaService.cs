namespace Core.Service
{
	public interface IAtividadeExternaService
	{
		uint Create(AtividadeExterna atividadeExterna);
		void Edit(AtividadeExterna atividadeExterna);
		void Delete(int id);
		AtividadeExterna? Get(int id);
	}
}
