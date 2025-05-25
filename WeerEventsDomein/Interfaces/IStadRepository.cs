using WeerEventsDomein.Model;

namespace WeerEventsDomein.Interfaces;

public interface IStadRepository
{
    IEnumerable<Stad> GetSteden();
}