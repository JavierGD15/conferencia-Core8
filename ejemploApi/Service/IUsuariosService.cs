using ejemploApi.Domain.Model;

namespace ejemploApi.Service
{
    public interface IUsuariosService
    {
        Task<Usuario> GetUsuarioById(int id);
        Task<List<Usuario>> GetUsuarios();
    }
}
