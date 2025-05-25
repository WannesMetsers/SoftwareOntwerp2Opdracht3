using WeerEvents.Dto;

namespace WeerEventsDomein.Facade.Controllers;

public interface IDomeinController
{
    IEnumerable<StadDto> GeefSteden();
    
    IEnumerable<WeerStationDto> GeefWeerstations();

    IEnumerable<MetingDto> GeefMetingen();
    
    void DoeMetingen();
    
    WeerBerichtDto GeefWeerbericht();
}