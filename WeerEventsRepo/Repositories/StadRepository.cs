using System.Text.Json;
using WeerEventsDomein.Interfaces;
using WeerEventsDomein.Model;
namespace WeerEventsRepo.Repositories;

public class StadRepository : IStadRepository
{
    public IEnumerable<Stad> GetSteden()
    {
        return JsonSerializer.Deserialize<List<Stad>>(File.ReadAllText("Steden/Data/steden.json"))!;
    }


}