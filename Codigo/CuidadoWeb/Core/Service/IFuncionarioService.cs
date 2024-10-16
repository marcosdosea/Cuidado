using Core.DTO;

namespace Core.Service
{
	public interface IFuncionarioService
	{
      int Create(Funcionario funcionario);
      void Edit(Funcionario funcionario);
      void Delete(int id);
      Funcionario? Get(int id);
      IEnumerable<Funcionario> GetAll();
      Task<FuncionarioDTO?> BuscarFuncionarioPorCpf(string cpf);
    }
}
