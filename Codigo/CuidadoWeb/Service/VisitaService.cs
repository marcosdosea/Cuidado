using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class VisitaService : IVisitaService
    {
        private readonly CuidadoContext context;

        public VisitaService(CuidadoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar um novo visita na base dados
        /// </summary>
        /// <param name="visita">Dados do visita</param>
        /// <returns>Id do produto</returns>
        public int Create(Visitum visita)
        {
            this.context.Add(visita);
            this.context.SaveChanges();
            return visita.Id;
        }

        /// <summary>s
        /// Remover o visita da base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var visita = this.context.Visita.Find(id);
            if (visita != null)
            {
                this.context.Remove(visita);
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do visita na base de dados
        /// </summary>
        /// <param name="visita"></param>
        public void Edit(Visitum visita)
        {
            this.context.Update(visita);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Buscar um visita na base de dados
        /// </summary>
        /// <param name="id">Id do visita</param>
        /// <returns>Dados do visita</returns>
        public Visitum? Get(int id)
        {
            return this.context.Visitan.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Visita> GetAll()
        {
            return this.context.Visita.AsNoTracking();
        }

    }
}
