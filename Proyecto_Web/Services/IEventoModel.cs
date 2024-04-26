using Proyecto_Web.Entidades;

namespace Proyecto_Web.Services
{
        public interface IEventoModel
        {
            EventoRespuesta? ConsultarEventos(bool MostrarTodos);
            EventoRespuesta? ConsultarEvento(long IdEvento);
            Respuesta? RegistrarEvento(Evento entidad);
            Respuesta? ActualizarEvento(Evento entidad);
            Respuesta? EliminarEvento(long IdEvento);
        }
}
