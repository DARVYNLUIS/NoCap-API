using NoCap_Services.DI;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NoCap API",
        Version = "v1",
        Description = "API para NoCap_Services"
    });
});
builder.Services.RegistarServices();

var app = builder.Build();

app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoCap API v1");
    c.RoutePrefix = "swagger"; 
});

app.UseDeveloperExceptionPage(); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
