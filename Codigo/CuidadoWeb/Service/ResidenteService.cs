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
		public int Create(Residente residente)
		{
			this.context.Add(residente);
			this.context.SaveChanges();
			return residente.Id;
		}

		/// <summary>s
		/// Remover o Residente da base de dados
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			var residente = this.context.Residentes.Find(id);
			if(residente != null)
			{
				this.context.Remove(residente);
				this.context.SaveChanges();
			}
		}

		/// <summary>
		/// Editar dados do Residente na base de dados
		/// </summary>
		/// <param name="Residente"></param>
		public void Edit(Residente residente)
		{
			this.context.Update(residente);
			this.context.SaveChanges();
		}

		/// <summary>
		/// Buscar um Residente na base de dados
		/// </summary>
		/// <param name="id">Id do Residente</param>
		/// <returns>Dados do Residente</returns>
		public Residente? Get(int id)
		{
			return this.context.Residentes.FirstOrDefault( a => a.Id == id);
		}

		public IEnumerable<Residente> GetAll()
		{
			return this.context.Residentes.AsNoTracking();
		}

	}
}
