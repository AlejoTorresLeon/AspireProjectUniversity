using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


// Nuevo endpoint para /departamentos
app.MapGet("/departamentos", async () =>
{
    using var httpClient = new HttpClient();
    var departamentosJson = await httpClient.GetFromJsonAsync<List<DepartamentoApi>>("https://api-colombia.com/api/v1/Department");

    if (departamentosJson is null)
        return Results.NotFound();

    var departamentosFiltrados = departamentosJson
        .Select(d => new Departamentos(d.Id, d.Name, d.Description))
        .ToList();

    return Results.Ok(departamentosFiltrados);
})
.WithName("GetDepartamentos");


// Endpoint para Ciudades
app.MapGet("/ciudades", async () =>
{
    using var httpClient = new HttpClient();
    var ciudadesJson = await httpClient.GetFromJsonAsync<List<CiudadApi>>("https://api-colombia.com/api/v1/City");

    if (ciudadesJson is null)
        return Results.NotFound();

    var ciudadesFiltradas = ciudadesJson
        .Select(c => new Ciudad(c.Id, c.Name, c.Description))
        .ToList();

    return Results.Ok(ciudadesFiltradas);
})
.WithName("GetCiudades");

// Endpoint para Presidentes
app.MapGet("/presidentes", async () =>
{
    using var httpClient = new HttpClient();
    var presidentesJson = await httpClient.GetFromJsonAsync<List<PresidenteApi>>("https://api-colombia.com/api/v1/President");

    if (presidentesJson is null)
        return Results.NotFound();

    var presidentesFiltrados = presidentesJson
        .Select(p => new Presidente(
            p.Id,
            $"{p.Name} {p.LastName}",
            p.Image,
            p.Description
        ))
        .ToList();

    return Results.Ok(presidentesFiltrados);
})
.WithName("GetPresidentes");



app.MapGet("/atracciones", async () =>
{
    using var httpClient = new HttpClient();
    var atraccionesJson = await httpClient.GetFromJsonAsync<List<AtracionesApi>>("https://api-colombia.com/api/v1/TouristicAttraction");

    if (atraccionesJson is null)
        return Results.NotFound();

    var atraccionesFiltradas = atraccionesJson
        .Select(c => new Atracion(c.Id, c.Name, c.Description))
        .ToList();

    return Results.Ok(atraccionesFiltradas);
})
.WithName("GetAtracciones");


app.MapDefaultEndpoints();

app.Run();






// Records para resultados
record Departamentos(int Id, string? Name, string? Description);
record Ciudad(int Id, string? Name, string? Description);
record Presidente(int Id, string FullName, string? UrlImage, string? Description);
record Atracion(int Id, string? Name, string? Description);

// Records para deserialización
record DepartamentoApi(int Id, string? Name, string? Description);
record CiudadApi(int Id, string? Name, string? Description);
record AtracionesApi(int Id, string? Name, string? Description);
record PresidenteApi(int Id, string Name, string LastName, string? Image, string? Description);

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
