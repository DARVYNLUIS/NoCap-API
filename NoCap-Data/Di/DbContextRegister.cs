using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoCap_Data.Context;

namespace NoCap_Data.Di;

public static class DbContextRegister
{
    public static IServiceCollection AddDbContextRegister(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlConStr");

        services.AddDbContextFactory<NoCapContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
