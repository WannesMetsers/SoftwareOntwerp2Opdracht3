using WeerEventsDomein.Model;

namespace WeerEventsDomein.Logging;

public class MetingLogger : IMetingLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void Log(Meting meting)
    {
        throw new NotImplementedException();
    }
}