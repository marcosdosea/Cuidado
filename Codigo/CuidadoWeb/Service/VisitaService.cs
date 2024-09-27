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
        /// Criar um novo Visita na base dados
        /// </summary>
        /// <param name="Visita">Dados do Visita</param>
        /// <returns>Id do produto</returns>
        public int Create(Visitum Visita)
        {
            this.context.Add(Visita);
            this.context.SaveChanges();
            return Visita.Id;
        }

        /// <summary>s
        /// Remover o Visita da base de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var Visita = this.context.Visitas.Find(id);
            if (Visita != null)
            {
                this.context.Remove(Visita);
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Editar dados do Visita na base de dados
        /// </summary>
        /// <param name="Visita"></param>
        public void Edit(Visitum Visita)
        {
            this.context.Update(Visita);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Buscar um Visita na base de dados
        /// </summary>
        /// <param name="id">Id do Visita</param>
        /// <returns>Dados do Visita</returns>
        public Visitum? Get(int id)
        {
            return this.context.Visitas.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Visita> GetAll()
        {
            return this.context.Visitas.AsNoTracking();
        }

    }
}
