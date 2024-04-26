using Proyecto_Web.Entidades;

namespace Proyecto_Web.Services
{
    public interface IUsuarioModel
    {
        Respuesta? RegistrarUsuario(Usuario entidad);

        UsuarioRespuesta? IniciarSesion(Usuario entidad);

        UsuarioRespuesta? RecuperarAcceso(Usuario entidad);

        UsuarioRespuesta? CambiarContrasenna(Usuario entidad);
    }
}
