namespace WeerEvents.Dto;

public class WeerStationDto
{
    public required StadDto Stad { get; set; }

    public required List<MetingDto> Metingen {get; set;}
}