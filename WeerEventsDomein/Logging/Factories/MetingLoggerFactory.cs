namespace WeerEventsDomein.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson = false, bool decorateWithXml = false)
    {
        IMetingLogger logger = new MetingLogger(); // basisimplementatie

        if (decorateWithJson)
        {
            logger = new JsonMetingLoggerDecorator(logger);
        }

        if (decorateWithXml)
        {
            logger = new XmlMetingLoggerDecorator(logger);
        }

        return logger;
    }
}
