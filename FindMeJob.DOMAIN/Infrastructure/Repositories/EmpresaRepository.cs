using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly FMJDbContext _dbContext;

        public EmpresaRepository(FMJDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var empresa = await _dbContext
                            .Empresas
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            if (empresa == null)
                return false;

            _dbContext.Empresas.Remove(empresa);

            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;    
        }

        public async Task<IEnumerable<Empresa>> GetAll()
        {
            var result = await _dbContext.Empresas.ToListAsync();
            return result;
        }

        public async Task<Empresa> GetById(int id)
        {
            var result = await _dbContext
                .Empresas
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Insert(Empresa empresa)
        {
            await _dbContext.Empresas.AddAsync(empresa);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public Task<Empresa> Login(string email, string password)
        {
            var result = _dbContext
                .Empresas
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Empresa empresa)
        {
            _dbContext.Empresas.Update(empresa);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
