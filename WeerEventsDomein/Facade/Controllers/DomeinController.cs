using WeerEvents.Dto;
using WeerEventsDomein.Factories;
using WeerEventsDomein.Logging.Factories;
using WeerEventsDomein.Model;
using WeerEventsDomein.Steden.Managers;

namespace WeerEventsDomein.Facade.Controllers;

public class DomeinController(IStadManager stadManager, IWeerstationManager weerstationManager, IWeerberichtManager weerberichtManager) : IDomeinController
{
    private readonly IStadManager _stadManager = stadManager;
    private readonly IWeerstationManager _weerstationManager = weerstationManager;
    private readonly IWeerberichtManager _weerberichtManager = weerberichtManager;

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations()
    {
        return _weerstationManager.GeefWeerStations()
       .Select(w => new WeerStationDto
       {
           Stad = new StadDto
           {
               Naam = w.Locatie.Naam,
               Beschrijving = w.Locatie.Beschrijving,
               GekendVoor = w.Locatie.GekendVoor
           }
       });
       
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {
        return _weerstationManager.GeefKopieMetingen().Select(m => new MetingDto
        {
            MetingTijd = m.MetingTijd,
            Waarde = m.Waarde,
            Eenheid = m.Eenheid.ToString(),
            Locatie = m.Locatie.Naam


        });
        
    }

    public void DoeMetingen()
    {
        _weerstationManager.DoeMeting();
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        Weerbericht weerbericht = _weerberichtManager.GeefWeerbericht();
        var metingen = _weerstationManager.GeefKopieMetingen();
        return new WeerBerichtDto
        {
            MomentCreatie = weerbericht.MomentCreatie,
            Tekst = weerbericht.Tekst
        };
    }
}