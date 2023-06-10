using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Interfaces
{
    public interface IPerfilProfesionalRepository
    {
        Task<IEnumerable<PerfilProfesional>> GetAll();
        Task<PerfilProfesional> GetById(int id);
        Task<bool> Insert(PerfilProfesional perfilProfesional);
        Task<bool> Update(PerfilProfesional perfilProfesional);
        Task<bool> Delete(int id);
        Task<IEnumerable<PerfilProfesional>> GetPerfilProfesionalByDescripcion(string descripcion);
    }
}
