using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoCap_Abstracions;
using NoCap_Data.Di;
using NoCap_Services;

public static class ServicesRegistar
{
    public static IServiceCollection RegistarServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextRegister(configuration); // <<< Ahora con configuración real

        services.AddScoped<IMarcaServices, MarcaServices>();
        services.AddScoped<ICategoriaServices, CategoriaService>();
        services.AddScoped<IUsuarioServices, UsuarioServices>();
        services.AddScoped<IProductoServices, ProductoServices>();
        services.AddScoped<ICarritoServices, CarritoServices>();
        services.AddScoped<IOrdenCompraServices, OrdenCompraServices>();

        return services;
    }
}
