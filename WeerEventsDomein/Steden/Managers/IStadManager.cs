using WeerEventsDomein.Model;

namespace WeerEventsDomein.Steden.Managers;

public interface IStadManager
{
    IEnumerable<Stad> GeefSteden();
}