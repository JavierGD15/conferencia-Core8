using ejemploApi.Domain.Model;
using ejemploApi.Repository;

namespace ejemploApi.Service.ServiceImplement
{
    public class UsuariosSevice : IUsuariosService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosSevice(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<Usuario> GetUsuarioById(int id)
        {
           return await _usuarioRepository.GetUsuarioById(id);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _usuarioRepository.GetUsuarios();
        }
    }
}
