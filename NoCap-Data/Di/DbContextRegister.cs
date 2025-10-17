using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoCap_Data.Context;

namespace NoCap_Data.Di;

public static class DbContextRegister
{
    public static IServiceCollection AddDbContextRegister(this IServiceCollection services)
    {
        services.AddDbContextFactory<NoCapContext>(options =>
        options.UseNpgsql("Name=SqlConStr"));
        return services;
    }
}
