using WeerEvents.Dto;
using WeerEventsDomein.Factories;
using WeerEventsDomein.Logging.Factories;
using WeerEventsDomein.Model;
using WeerEventsDomein.Steden.Managers;

namespace WeerEventsDomein.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerstationManager _weerstationManager;
   
   
    public DomeinController(IStadManager stadManager, IWeerstationManager weerstationManager)
    {
        
        _stadManager = stadManager;
        _weerstationManager = weerstationManager;
        
    }
    
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
           },
           Metingen = w.GeefMetingen().Select(m => new MetingDto
           {
               MetingTijd = m.MetingTijd,
               Waarde = m.Waarde,
               Eenheid = m.Eenheid.ToString(),
               Locatie = m.Locatie.Naam
           }).ToList()
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
        //TODO
        throw new NotImplementedException();
    }
}