using Proyecto_Web.Entidades;

namespace Proyecto_Web.Entidades
{
    public class Evento
    {
        public long IdEvento { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string? Ubicacion { get; set; }
        public decimal Precio { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public bool Estado { get; set; }
    }
}

    public class EventoRespuesta
    {
        public EventoRespuesta()
        {
            Codigo = "00";
            Mensaje = string.Empty;
        }

        public string? Codigo { get; set; }
        public string? Mensaje { get; set; }
        public Evento? Dato { get; set; }
        public List<Evento>? Datos { get; set; }
    }

