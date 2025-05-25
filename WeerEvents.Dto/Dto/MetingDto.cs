namespace WeerEvents.Dto;

public class MetingDto
{
    

    public required DateTime MetingTijd { get; set; }

    public required double Waarde { get; set; }

    public required string Eenheid { get; set; }

    public required string Locatie { get; set; }
}