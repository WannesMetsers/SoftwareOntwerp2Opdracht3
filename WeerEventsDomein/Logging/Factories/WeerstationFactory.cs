using WeerEventsDomein.Interfaces;
using WeerEventsDomein.Logging.Factories;
using WeerEventsDomein.Model;
using WeerEventsDomein.Model.Weerstations;


namespace WeerEventsDomein.Factories;

public class WeerstationFactory : IWeerstationFactory
{
    private readonly IStadRepository _stadRepo;
    private readonly Random _random = new();

    public WeerstationFactory(IStadRepository stadRepo)
    {
        _stadRepo = stadRepo;
    }

    public List<Weerstation> MaakWeerstations()
    {
        var steden = _stadRepo.GetSteden();
        var lijst = new List<Weerstation>();

        for (int i = 0; i < 12; i++)
        {
            var stad = steden[_random.Next(steden.Count)];

            Weerstation station = i % 4 switch
            {
                0 => new Temperatuur { Locatie = stad, Metingen = new() },
                1 => new Wind { Locatie = stad, Metingen = new() },
                2 => new Neerslag { Locatie = stad, Metingen = new() },
                3 => new Luchtdruk { Locatie = stad, Metingen = new() },
                _ => throw new Exception("Onbekend type")
            };

            lijst.Add(station);
        }

        return lijst;
    }
}
