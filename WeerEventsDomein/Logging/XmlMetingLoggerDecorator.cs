using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Logging
{
    public class XmlMetingLoggerDecorator : IMetingLogger
    {
        private readonly IMetingLogger _inner;

        public XmlMetingLoggerDecorator(IMetingLogger inner)
        {
            _inner = inner;
        }

        public void Log(Meting meting)
        {
            _inner.Log(meting); 
            var xml = $"""
        <Meting>
            <Moment>{meting.MetingTijd}</Moment>
            <Waarde>{meting.Waarde}</Waarde>
            <Eenheid>{meting.Eenheid}</Eenheid>
        </Meting>
        """;
            File.AppendAllText("log.xml", xml + Environment.NewLine);
        }

        public void Log(string message)
        {
            Console.WriteLine("XmlMetingLoggerDecorator");
        }
    }

}
