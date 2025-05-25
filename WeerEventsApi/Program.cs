using WeerEventsDomein.Facade.Controllers;
using WeerEventsDomein.Logging;
using WeerEventsDomein.Logging.Factories;
using WeerEventsDomein.Steden.Managers;
using WeerEventsDomein.Interfaces;
using WeerEventsDomein.Factories;
using WeerEventsDomein.Logging.Factories;
using WeerEventsRepo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true,true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();

var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());
builder.Services.AddSingleton<IWeerstationFactory, WeerstationFactory>();

//TODO api aanvullen

app.Run();