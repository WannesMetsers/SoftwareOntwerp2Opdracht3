using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Logging.Factories
{
     public interface IWeerstationFactory
    {
        List<Weerstation> MaakWeerstations();
    }
}
