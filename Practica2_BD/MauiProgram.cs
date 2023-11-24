using Microsoft.Extensions.Logging;
using Practica2_BD.Modelo;
using Practica2_BD.Repositorios;

namespace Practica2_BD
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            String ruta = obtenerRutaBD.devolverRuta("totalUsuarios.db");
            builder.Services.AddSingleton<UsuarioRepositorio>(
            s => ActivatorUtilities.CreateInstance<UsuarioRepositorio>(s, ruta));
            return builder.Build();
        }
    }
}