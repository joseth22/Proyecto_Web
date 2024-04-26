using Proyecto_Web.Models;
using Proyecto_Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Agregar el soporte para sesiones.
builder.Services.AddSession();

// Registrar HttpClient para poder realizar llamadas HTTP a servicios externos.
builder.Services.AddHttpClient();

// Permitir el acceso al HttpContext fuera de los controladores.
builder.Services.AddHttpContextAccessor();

// Registrar tus modelos y servicios personalizados como singleton.
builder.Services.AddSingleton<IUsuarioModel, UsuarioModel>();
builder.Services.AddSingleton<IUtilitariosModel, UtilitariosModel>();

builder.Services.AddSingleton<IEventoModel, EventoModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Home/Error");
  //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Importante: Agregar el middleware de sesiones después de UseRouting() y antes de UseEndpoints().
app.UseSession();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=IniciarSesion}/{id?}");

app.Run();
