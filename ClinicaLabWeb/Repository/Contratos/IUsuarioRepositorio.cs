using SistemaClinicaLab.Models;
using System.Linq.Expressions;

namespace SistemaClinicaLab.Repository.Contratos
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> Lista();
        Task<Usuario> Obtener(string email, string clave);
        Task<Usuario> Obtener(int idUsuario);
        Task<IEnumerable<Usuario>> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
    }
}
