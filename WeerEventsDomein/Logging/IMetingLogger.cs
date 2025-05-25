using WeerEventsDomein.Model;

namespace WeerEventsDomein.Logging;

public interface IMetingLogger
{
    void Log(string message);
    void Log(Meting meting);
}