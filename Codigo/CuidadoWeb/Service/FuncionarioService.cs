using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class FuncionarioService : IFuncionarioService
	{
		private readonly CuidadoContext context;

		public FuncionarioService(CuidadoContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Criar um novo funcionário na base dados
		/// </summary>
		/// <param name="funcionario">Dados do funcionário</param>
		/// <returns>Id do funcionário</returns>
		public int Create(Funcionario funcionario)
		{
			this.context.Add(funcionario);
			this.context.SaveChanges();
			return funcionario.Id;
		}

		/// <summary>s
		/// Remover o funcionário da base de dados
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			var funcionario = this.context.Funcionarios.Find(id);
			if (funcionario != null)
			{
				this.context.Remove(funcionario);
				this.context.SaveChanges();
			}
		}

		/// <summary>
		/// Editar dados do funcionário na base de dados
		/// </summary>
		/// <param name="funcionario"></param>
		public void Edit(Funcionario funcionario)
		{
			this.context.Update(funcionario);
			this.context.SaveChanges();
		}

		/// <summary>
		/// Buscar um funcionário na base de dados
		/// </summary>
		/// <param name="id">Id do funcionário</param>
		/// <returns>Dados do funcionário</returns>
		public Funcionario? Get(int id)
		{
			return this.context.Funcionarios.FirstOrDefault(a => a.Id == id);
		}

		public IEnumerable<Funcionario> GetAll()
		{
			return this.context.Funcionarios.AsNoTracking();
		}

	}
}
