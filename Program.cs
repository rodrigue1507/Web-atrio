using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using Web_atrio;
using Web_atrio.Donnees;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlite<PersonneContext>("Data Source=personne.db");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Personne-emploi API",
        Description = "An ASP.NET Core Web API for managing Personne-emploi",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});
builder.Services.AddTransient<PersonneService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.CreateDbIfNotExists();
app.MapGet("/personnes", ([FromServices] PersonneService personneService) =>
{
    var personnes = personneService.GetAll();
    if(personnes is not null) return Results.Ok(personnes);
    return Results.NotFound();
});
app.MapGet("/personnes/{id}", (int personneId, PersonneService personneService) =>
{
    var personne = personneService.GetById(personneId);
    if (personne is not null) return Results.Ok(personne);
    return Results.NotFound();
});
app.MapPut("/personnes/{id}",  (int personneId, Emploi emploi, PersonneService personneService) =>
{
    personneService.AddEmploi(personneId, emploi);
    return Results.NoContent();
});
app.MapPost("/personnes", (Personne personne, PersonneService personneService) =>
{
    var nouvelpersonne = personneService.Create(personne);
    return Results.Created($"/personnes/{nouvelpersonne.Id}", nouvelpersonne);
});
//app.MapDelete("/personnes",(PersonneService personneService) => 
//{
//    personneService.DeleteAll();
//    return Results.NoContent();
//});

app.Run();
