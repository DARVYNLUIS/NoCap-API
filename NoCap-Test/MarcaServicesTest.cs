using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NoCap_Data.Context;
using NoCap_Data.Data;
using NoCap_Services;

namespace NoCap_Test;

public class MarcaServicesTest
{
    private MarcaServices GetServiceTest()
    {
        var options = new DbContextOptionsBuilder<NoCapContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var factory = new PooledDbContextFactory<NoCapContext>(options);
        return new MarcaServices(factory);
    }

    [Fact]
    public async Task AddMarcaTestDevolverGuardado()
    {
        var service = GetServiceTest();
        var newMarca = new MarcasDto { MarcaId = 1, Nombre = "Nike" };
        var result = await service.Guardar(newMarca);
        Assert.True(result);
    }

    [Fact]
    public async Task ListMarcaTest()
    {
        var service = GetServiceTest();
        await service.Guardar(new MarcasDto { MarcaId = 1, Nombre = "Nike" });

        var lista = await service.ListMarcas(s => true);
        Assert.Equal("Nike", lista[0].Nombre);
    }

    [Fact]
    public async Task DeleteMarcaTest()
    {
        var service = GetServiceTest();
        await service.Guardar(new MarcasDto { MarcaId = 1, Nombre = "Nike" });
        var result = await service.DeleteMarca(1);
        Assert.True(result);
    }
}
