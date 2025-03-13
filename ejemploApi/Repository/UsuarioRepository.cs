using ejemploApi.Domain.Model;
using ejemploApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioById(int id);
        Task<List<Usuario>> GetUsuarios();
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
