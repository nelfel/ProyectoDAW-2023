using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Interfaces
{
    public interface IPostulacionRepository
    {
        Task<IEnumerable<Postulacion>> GetAll();
        Task<Postulacion> GetById(int id);
        Task<bool> Insert(Postulacion postulacion);
        Task<bool> Update(Postulacion postulacion);
        Task<bool> Delete(int id);
        Task<IEnumerable<Postulacion>> GetPostulacionesByOfertaTrabajo(int idOfertaTrabajo);
        Task<IEnumerable<Postulacion>> GetPostulacionesByUsuario(int idUsuario);
    }
}
