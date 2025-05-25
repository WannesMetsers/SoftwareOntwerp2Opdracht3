
using WeerEventsDomein.Steden.Managers;
using WeerEventsDomein.Interfaces;
using WeerEventsDomein.Model;


namespace WeerEventsDomein.Steden.Managers;

public class StadManager(IStadRepository repository) : IStadManager
{
    public IEnumerable<Stad> GeefSteden()
    {
        return repository.GetSteden();
    }

   
}