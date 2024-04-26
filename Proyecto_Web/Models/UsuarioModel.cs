﻿using Proyecto_Web.Entidades;
using Proyecto_Web.Services;

namespace Proyecto_Web.Models
{
    public class UsuarioModel(HttpClient _httpClient, IConfiguration _configuration) : IUsuarioModel
    {
        public Respuesta? RegistrarUsuario(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/RegistrarUsuario";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Respuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? IniciarSesion(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/IniciarSesion";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? RecuperarAcceso(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/RecuperarAcceso";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }

        public UsuarioRespuesta? CambiarContrasenna(Usuario entidad)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/Usuario/CambiarContrasenna";
            JsonContent body = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioRespuesta>().Result;

            return null;
        }
    }
}
