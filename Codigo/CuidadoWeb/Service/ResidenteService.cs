using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class ResidenteService : IResidenteService
	{
		private readonly CuidadoContext context;

		public ResidenteService(CuidadoContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Criar um novo Residente na base dados
		/// </summary>
		/// <param name="Residente">Dados do Residente</param>
		/// <returns>Id do Residente</returns>
		public int Create(Residente Residente)
		{
			this.context.Add(Residente);
			this.context.SaveChanges();
			return Residente.Id;
		}

		/// <summary>s
		/// Remover o Residente da base de dados
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			var Residente = this.context.Residente.Find(id);
			if(Residente != null)
			{
				this.context.Remove(Residente);
				this.context.SaveChanges();
			}
		}

		/// <summary>
		/// Editar dados do Residente na base de dados
		/// </summary>
		/// <param name="Residente"></param>
		public void Edit(Residente Residente)
		{
			this.context.Update(Residente);
			this.context.SaveChanges();
		}

		/// <summary>
		/// Buscar um Residente na base de dados
		/// </summary>
		/// <param name="id">Id do Residente</param>
		/// <returns>Dados do Residente</returns>
		public Residente? Get(int id)
		{
			return this.context.Residente.FirstOrDefault( a => a.Id == id);
		}

		public IEnumerable<Residente> GetAll()
		{
			return this.context.Residente.AsNoTracking();
		}

	}
}
