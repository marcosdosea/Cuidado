namespace Core.Service
{
    public interface IVisitanteService
    {
        int Create(Visitante visitante);
        void Edit(Visitante visitante);
        void Delete(int id);
        Visitante? Get(int id);
        IEnumerable<Visitante> GetAll();
    }
}
