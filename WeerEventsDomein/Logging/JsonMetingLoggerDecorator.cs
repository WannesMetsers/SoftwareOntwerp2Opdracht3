using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Logging
{
    public class JsonMetingLoggerDecorator : IMetingLogger
    {
        private readonly IMetingLogger _inner;

        public JsonMetingLoggerDecorator(IMetingLogger inner)
        {
            _inner = inner;
        }

        public void Log(Meting meting)
        {
            _inner.Log(meting); // eerst inner logger
            var json = JsonSerializer.Serialize(meting, new JsonSerializerOptions { WriteIndented = true });
            File.AppendAllText("log.json", json + Environment.NewLine);
        }

        public void Log(string message)
        {
            Console.WriteLine("JsonMetingLoggerDecorator");
        }
    }

}
