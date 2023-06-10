using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class OfertaTrabajoRepository : IOfertaTrabajoRepository
    {
        private readonly FMJDbContext _dbContext;
        public OfertaTrabajoRepository(FMJDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext
                            .OfertaTrabajos
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync(); 
           if (item == null)
                return false;

            _dbContext.OfertaTrabajos.Remove(item);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<OfertaTrabajo>> GetAll()
        {
            var result = await _dbContext.OfertaTrabajos.ToListAsync();
            return result;
        }

        public async Task<OfertaTrabajo> GetById(int id)
        {
            var result = await _dbContext
                .OfertaTrabajos
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<OfertaTrabajo>> GetOfertasTrabajoByUsuario(int idUsuario)
        {
            var result = await _dbContext
                .OfertaTrabajos
                .Where(x => x.EmpresaId == idUsuario)
                .ToListAsync();

            return result;
        }

        public async Task<bool> Insert(OfertaTrabajo ofertaTrabajo)
        {
            await _dbContext.OfertaTrabajos.AddAsync(ofertaTrabajo);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(OfertaTrabajo ofertaTrabajo)
        {
            _dbContext.OfertaTrabajos.Update(ofertaTrabajo);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
