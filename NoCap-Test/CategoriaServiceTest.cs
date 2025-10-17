using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NoCap_Data.Context;
using NoCap_Data.Data;
using NoCap_Services;

namespace NoCap_Test;

public class CategoriaServiceTest
{
    private CategoriaService GetServiceTest() 
    {
        var options = new DbContextOptionsBuilder<NoCapContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var factory = new PooledDbContextFactory<NoCapContext>(options);
        return new CategoriaService(factory);
    }

    [Fact]
    public async Task Guardar_Insertar()
    {
        var service = GetServiceTest();
        var categoriaDto = new CategoriasDto
        {
            CategoriaId = 1,
            nombre = "Categoria Test",
            descripcion = "Descripcion Test"
        };

        var result = await service.Guardar(categoriaDto);
        var lista = await service.ListCategorias(c => true);

        Assert.Single(lista);
        Assert.Equal("Categoria Test", lista[0].nombre);
    }

    [Fact]
    public async Task Guardar_Modificar()
    {
        var service = GetServiceTest();
        var categoriaDto = new CategoriasDto
        {
            CategoriaId = 1,
            nombre = "Categoria Test",
            descripcion = "Descripcion Test Modificada"
        };

        var result = await service.Guardar(categoriaDto);


        var lista = await service.ListCategorias(c => true);
        Assert.Single(lista);
        Assert.Equal("Descripcion Test Modificada", lista[0].descripcion);
    }

    [Fact]
    public async Task ObtenerPorId()
    {
        var service = GetServiceTest();

        var dto = new CategoriasDto
        {
            CategoriaId = 1,
            nombre = "Categoria Test",
            descripcion = "Descripcion Test"
        };

        await service.Guardar(dto);
        var categoria = await service.GetCategoriaById(1);

        Assert.Equal("Categoria Test", categoria.nombre);
    }

    [Fact]
    public async Task Existe_False()
    {
        var service = GetServiceTest();

        var resultado = await service.Existe(1);

        Assert.False(resultado);
    }
    
    [Fact]
    public async Task Existe_True()
    {
        var service = GetServiceTest();
        var dto = new CategoriasDto
        {
            CategoriaId = 1,
            nombre = "Categoria Test",
            descripcion = "Descripcion Test"
        };

        await service.Guardar(dto);
        var resultado = await service.Existe(1);

        Assert.True(resultado);
    }
}
