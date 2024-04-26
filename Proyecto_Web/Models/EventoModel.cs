using Microsoft.AspNetCore.Mvc;
using Proyecto_Web.Entidades;
using Proyecto_Web.Services;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Proyecto_Web.Models
{
        public class EventoModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IEventoModel
        {
            public EventoRespuesta? ConsultarEventos(bool MostrarTodos)
            {
                string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Evento/ConsultarEventos?MostrarTodos=" + MostrarTodos;

                string token = _context.HttpContext?.Session.GetString("Token")!;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var resp = _httpClient.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<EventoRespuesta>().Result;

                return null;
            }

            public EventoRespuesta? ConsultarEvento(long IdEvento)
            {
                string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Evento/ConsultarEvento?IdEvento=" + IdEvento;

                string token = _context.HttpContext?.Session.GetString("Token")!;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var resp = _httpClient.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<EventoRespuesta>().Result;

                return null;
            }

            public Respuesta? RegistrarEvento(Evento entidad)
            {
                string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Evento/RegistrarEvento";

                string token = _context.HttpContext?.Session.GetString("Token")!;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                JsonContent body = JsonContent.Create(entidad);
                var resp = _httpClient.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

                return null;
            }

            public Respuesta? ActualizarEvento(Evento entidad)
            {
                string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Evento/ActualizarEvento";

                string token = _context.HttpContext?.Session.GetString("Token")!;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                JsonContent body = JsonContent.Create(entidad);
                var resp = _httpClient.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

                return null;
            }

            public Respuesta? EliminarEvento(long IdEvento)
            {
                string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Servicio/EliminarEvento?IdEvento=" + IdEvento;

                string token = _context.HttpContext?.Session.GetString("Token")!;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var resp = _httpClient.DeleteAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

                return null;
            }

        }
    }
