using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Interfaces
{
    public interface IOfertaTrabajoRepository
    {
        Task<IEnumerable<OfertaTrabajo>> GetAll();
        Task<OfertaTrabajo> GetById(int id);
        Task<bool> Insert(OfertaTrabajo ofertaTrabajo);
        Task<bool> Update(OfertaTrabajo ofertaTrabajo);
        Task<bool> Delete(int id);  
        Task<IEnumerable<OfertaTrabajo>> GetOfertasTrabajoByUsuario(int idUsuario);
    }
}
