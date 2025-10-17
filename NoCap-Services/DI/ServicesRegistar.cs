using Microsoft.Extensions.DependencyInjection;
using NoCap_Abstracions;
using NoCap_Data.Di;

namespace NoCap_Services.DI;

public static class ServicesRegistar
{
    public static IServiceCollection RegistarServices (this IServiceCollection services)
    {
        services.AddDbContextRegister();
        services.AddScoped<IMarcaServices, MarcaServices>();
        services.AddScoped<ICategoriaServices, CategoriaService>();
        services.AddScoped<ITamañoServices, TamañosServices>();
        services.AddScoped<IColoresServices, ColoreServices>();
        services.AddScoped<IUsuarioServices, UsuarioServices>();
        services.AddScoped<IProductoServices, ProductoServices>();
        services.AddScoped<ICarritoServices, CarritoServices>();
        services.AddScoped<IOrdenCompraServices, OrdenCompraServices>();

        return services;
    }
}
