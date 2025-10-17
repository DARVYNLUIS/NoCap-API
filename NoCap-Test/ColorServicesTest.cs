using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NoCap_Data.Context;
using NoCap_Data.Data;
using NoCap_Services;

namespace NoCap_Test;
public class ColorServicesTest
{
    private ColoreServices GetServiceTest()
    {
        var options = new DbContextOptionsBuilder<NoCapContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var factory = new PooledDbContextFactory<NoCapContext>(options);
        using (var context = factory.CreateDbContext())
        {
            context.Colores.AddRange(
                new Colores { ColorId = 1, Nombre = "prueba", CodigoHex = "snclasn" },
                new Colores { ColorId = 2, Nombre = "Prueba-1", CodigoHex ="jnkasnd" },
                new Colores { ColorId = 3, Nombre = "Prueba-2", CodigoHex ="ajqnds" }
            );
            context.SaveChanges();
        }
        return new ColoreServices(factory);
    }
    [Fact]
    public async Task ListColorTest()
    {
        var service = GetServiceTest();

        var lista = await service.ListColores(s => true);
        Assert.Equal(4, lista.Capacity);
    }
}