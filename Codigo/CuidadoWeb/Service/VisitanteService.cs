using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class VisitanteService : IVisitanteService
    {
        private readonly CuidadoContext context;

        public VisitanteService(CuidadoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Criar um novo visitante na base dados
        /// </summary>
        /// <param name="visitante">Dados do visitante</param>
        /// <returns>Id do produto</returns>
        public int Create(Visitante visitante)
        {
            this.context.Add(visitante);
            this.context.SaveChanges();
            return visitante.Id;
        }

        /// <summary>s
        /// Remover o visitante da base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var visitante = this.context.Visitante.Find(id);
            if (visitante != null)
            {
                this.context.Remove(visitante);
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do visitante na base de dados
        /// </summary>
        /// <param name="visitante"></param>
        public void Edit(Visitante visitante)
        {
            this.context.Update(visitante);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Buscar um visitante na base de dados
        /// </summary>
        /// <param name="id">Id do visitante</param>
        /// <returns>Dados do visitante</returns>
        public Visitante? Get(int id)
        {
            return this.context.Visitante.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Visitante> GetAll()
        {
            return this.context.Visitante.AsNoTracking();
        }

    }
}
