using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class CuidadoService : ICuidadoService
	{
		private readonly CuidadoContext context;

		public CuidadoService(CuidadoContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Criar um novo cuidado na base dados
		/// </summary>
		/// <param name="cuidado">Dados do cuidado</param>
		/// <returns>Id do cuidado</returns>
		public int Create(Cuidado cuidado)
		{
            this.context.Add(cuidado);
            this.context.SaveChanges();

            return cuidado.Id;
		}

		/// <summary>
		/// Remover o cuidado da base de dados
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
            var cuidado = this.context.Cuidados.Find(id);

            if (cuidado != null)
            {
                this.context.Remove(cuidado);
                this.context.SaveChanges();
            }
		}

		/// <summary>
		/// Editar dados do cuidado na base de dados
		/// </summary>
		/// <param name="produto"></param>
		public void Edit(Cuidado cuidado)
		{
			this.context.Update(cuidado);
			this.context.SaveChanges();
		}

		/// <summary>
		/// Buscar um cuidado na base de dados
		/// </summary>
		/// <param name="id">Id do cuidado</param>
		/// <returns>Dados do cuidado</returns>
		public Cuidado? Get(int id)
		{
            return this.context.Cuidados.Find(id);
		}

		/// <summary>
		/// Buscar um cuidado na base de dados
		/// </summary>
		/// <param name="id">Id do produto</param>
		/// <returns>Dados do produto</returns>
		public IEnumerable<Cuidado> GetAll()
		{
            return this.context.Cuidados.AsNoTracking();
		}

	}
}
