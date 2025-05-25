using WeerEventsDomein.Facade.Controllers;
using WeerEventsDomein.Logging;
using WeerEventsDomein.Logging.Factories;
using WeerEventsDomein.Steden.Managers;
using WeerEventsDomein.Interfaces;
using WeerEventsDomein.Factories;
using WeerEventsDomein.Logging.Factories;
using WeerEventsRepo.Repositories;
using WeerEventsDomein.Generators;
using WeerEventsDomein.Model;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IWeerberichtManager, WeerberichtManager>();

builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IWeerstationManager, WeerstationManager>();
builder.Services.AddSingleton<IWeerstationFactory, WeerstationFactory>();

builder.Services.AddSingleton<Func<IEnumerable<Meting>>>(sp =>
{
    var weerstationManager = sp.GetRequiredService<IWeerstationManager>();
    return () => weerstationManager.GeefKopieMetingen();
});

builder.Services.AddSingleton<IWeerberichtGenerator, EchteWeerberichtGenerator>();

builder.Services.AddSingleton<IDomeinController, DomeinController>();


var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());

app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());

app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());

app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());

app.MapPost("/commands/meting-command", (IDomeinController dc) =>
{
    dc.DoeMetingen();
    return Results.Ok("Metingen uitgevoerd voor alle weerstations.");
});




app.Run();