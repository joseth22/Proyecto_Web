using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using Proyecto_Web.Entidades;
using Proyecto_Web.Models;
using Proyecto_Web.Services;

namespace Proyecto_Web.Controllers
{
    public class EventoController(IEventoModel _eventoModel, IHostEnvironment _environment) : Controller
    {
        [HttpGet]
        public IActionResult ConsultarEventos()
        {
            var resp = _eventoModel.ConsultarEventos(true);

            if (resp?.Codigo == "00")
            {
                return View(resp!.Datos);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View(new List<Evento>());
            }
        }


        [HttpGet]
        public IActionResult RegistrarEvento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEvento(IFormFile Imagen, Evento entidad)
        {
            string ext = Path.GetExtension(Path.GetFileName(Imagen.FileName));
            string folder = Path.Combine(_environment.ContentRootPath, "wwwroot\\images");

            if (ext.ToLower() != ".png")
            {
                ViewBag.MsjPantalla = "La imagen debe ser .png";
                return View();
            }

            entidad.Imagen = "/images/";
            var resp = _eventoModel.RegistrarEvento(entidad);

            if (resp?.Codigo == "00")
            {
                string archivo = Path.Combine(folder, resp?.ConsecutivoGenerado + ext);
                using (Stream fileStream = new FileStream(archivo, FileMode.Create))
                {
                    Imagen.CopyTo(fileStream);
                }

                return RedirectToAction("ConsultarEventos", "Evento");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }


        [HttpGet]
        public IActionResult ActualizarEvento(long id)
        {
            var resp = _eventoModel.ConsultarEvento(id);

            if (resp?.Codigo == "00")
            {
                ViewBag.urlImagen = resp?.Dato?.Imagen;
                return View(resp!.Dato);
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }

        [HttpPost]
        public IActionResult ActualizarEvento(IFormFile Imagen, Evento entidad)
        {
            string ext = string.Empty;
            string folder = string.Empty;

            if (Imagen != null)
            {
                ext = Path.GetExtension(Path.GetFileName(Imagen.FileName));
                folder = Path.Combine(_environment.ContentRootPath, "wwwroot\\images");

                if (ext.ToLower() != ".png")
                {
                    ViewBag.MsjPantalla = "La imagen debe ser .png";
                    return View();
                }
            }

            var resp = _eventoModel.ActualizarEvento(entidad);

            if (resp?.Codigo == "00")
            {
                if (Imagen != null)
                {
                    string archivo = Path.Combine(folder, entidad.IdEvento + ext);
                    using (Stream fileStream = new FileStream(archivo, FileMode.Create))
                    {
                        Imagen.CopyTo(fileStream);
                    }
                }

                return RedirectToAction("ConsultarEventos", "Evento");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }


        [HttpPost]
        public IActionResult EliminarEvento(Evento entidad)
        {
            var resp = _eventoModel.EliminarEvento(entidad.IdEvento);

            if (resp?.Codigo == "00")
            {
                return RedirectToAction("ConsultarEventos", "Evento");
            }
            else
            {
                ViewBag.MsjPantalla = resp?.Mensaje;
                return View();
            }
        }

    }
}
