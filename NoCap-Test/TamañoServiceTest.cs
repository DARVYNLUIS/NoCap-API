using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NoCap_Data.Context;
using NoCap_Data.Data;
using NoCap_Services;

namespace NoCap_Test;
public class TamañoServiceTest
{
    private TamañosServices GetServiceTest()
    {
        var options = new DbContextOptionsBuilder<NoCapContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var factory = new PooledDbContextFactory<NoCapContext>(options);
        using (var context = factory.CreateDbContext())
        {
            context.Tamaños.AddRange(
                new Tamaños { TamañoId = 1, nombre = "Pequeño" },
                new Tamaños { TamañoId = 2, nombre = "Mediano" },
                new Tamaños { TamañoId = 3, nombre = "Grande" },
                new Tamaños { TamañoId = 4, nombre = "Extra Grande" }
            );
            context.SaveChanges();
        }
        return new TamañosServices(factory);
    }

    [Fact]
    public async Task ListSizeTest()
    {
        var service = GetServiceTest();
        
        
        var lista = await service.ListTamaño(s => true);
        Assert.Equal(4, lista.Capacity);
    }
}
