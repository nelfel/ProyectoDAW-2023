using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FMJDbContext _dbContext;

        public UsuarioRepository(FMJDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _dbContext
                            .Usuarios
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            _dbContext.Usuarios.Remove(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var result = await _dbContext.Usuarios.ToListAsync();
            return result;
        }

        public async Task<Usuario> GetById(int id)
        {
            var result = await _dbContext
               .Usuarios
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public Task<Usuario> Login(string email, string password)
        {
            var result = _dbContext
                .Usuarios
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
